using EasyGrocery.Domain.Entities;
using EasyGrocery.Domain.Repositories;
using MediatR;

namespace EasyGrocery.Application.Handlers.CustomerHandler.Queries
{
    public class GetCustomerByIdQueryHandler(ICustomerRepository customerRepository) :
        IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await customerRepository.GetCustomerById(request.Id);
        }
    }
}
