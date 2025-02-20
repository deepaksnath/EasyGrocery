using EasyGrocery.Application.Models;
using MediatR;

namespace EasyGrocery.Application.Handlers.OrderHandler.Commands
{
    public class AddOrderCommand : IRequest<Guid>
    {
        public AddOrderCommand(OrderModel? orderModel)
        {
            OrderModel = orderModel;
        }
        public OrderModel? OrderModel { get; set; }
    }
}
