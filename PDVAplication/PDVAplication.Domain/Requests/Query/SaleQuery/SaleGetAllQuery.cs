using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Sale;

namespace PDVAplication.Domain.Requests.Query.SaleQuery
{
    public class SaleGetAllQuery : IRequest<Result<List<SaleViewModel>>>, IValidatable
    {
    }
}
