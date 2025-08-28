using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Customer;

namespace PDVAplication.Domain.Requests.Query.CustomerQuery
{
    public class CustomerGetAllQuery :IRequest<Result<List<CustomerViewModel>>>, IValidatable
    {
    }
}
