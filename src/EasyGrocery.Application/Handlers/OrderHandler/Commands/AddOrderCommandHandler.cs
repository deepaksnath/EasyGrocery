using AutoMapper;
using EasyGroceries.Api.Services;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.OrderHandler.Commands
{
    public class AddOrderCommandHandler(IOrderRepository orderRepository,
                                        ICustomerRepository customerRepository,
                                        ICartItemRepository cartItemRepository,
                                        IOrderItemRepository orderItemRepository,
                                        IMapper mapper) :
                                        IRequestHandler<AddOrderCommand, Guid>
    {
        public async Task<Guid> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            Order order = mapper.Map<Order>(command.orderModel);
            if (order.CustomerId != Guid.Empty)
            {
                var customer = await customerRepository.GetCustomerById(order.CustomerId);
                var cartItems = await cartItemRepository.GetCartItemsByCustomerAsync(order.CustomerId);
                if (customer is not null &&
                        cartItems is not null &&
                        cartItems.Any(i => i.Quantity > 0))
                {
                    if (order.IsLoyaltyMembershipAdded)
                    {
                        cartItems.Add(new()
                        {
                            CustomerId = order.CustomerId,
                            Price = AppConstants.LOYALTY_MEMBERSHIP_PRICE,
                            Quantity = 1
                        });
                        customer.HasLoyaltyMembership = true;
                    }
                    var discount = AppConstants.LOYALTY_MEMBER_DISCOUNT;
                    List<OrderItem> orderItems = new();
                    decimal totalPrice = 0;
                    foreach (var cartItem in cartItems)
                    {
                        var unitPrice = cartItem.Price;
                        if (cartItem.ProductId != Guid.Empty)
                        {
                            cartItem.ProductId = Guid.NewGuid();
                            unitPrice = customer.HasLoyaltyMembership ?
                                    (unitPrice - (unitPrice * discount)) :
                                    unitPrice;
                        }
                        OrderItem orderItem = new()
                        {
                            CustomerId = cartItem.CustomerId,
                            ProductId = cartItem.ProductId,
                            Quantity = cartItem.Quantity,
                            Price = unitPrice
                        };
                        orderItems.Add(orderItem);
                        totalPrice += orderItem.Price * cartItem.Quantity;
                    }
                    order.TotalAmount = totalPrice;
                    order.OrderDate = DateTime.Now;
                    await orderRepository.CreateOrder(order);

                    orderItems.ForEach(item => { item.OrderId = order.Id; });

                    await orderItemRepository.CreateOrderItems(orderItems);

                    await cartItemRepository.RemoveCartItemsByCustomerAsync(order.CustomerId);

                    if (order.IsLoyaltyMembershipAdded)
                    {
                        await customerRepository.UpdateCustomers(customer);
                    }
                    return order.Id;
                }
            }
            return Guid.Empty;
        }
    }
}
