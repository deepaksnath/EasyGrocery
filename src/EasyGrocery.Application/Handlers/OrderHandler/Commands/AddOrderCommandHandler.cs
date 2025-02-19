using AutoMapper;
using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.OrderHandler.Commands
{
    public class AddOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper) :
                 IRequestHandler<AddOrderCommand, Guid>
    {
        public async Task<Guid> Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            Order order = mapper.Map<Order>(command.orderModel);
            var id = await orderRepository.CreateOrder(order);
            return id;
        }
    }
}
