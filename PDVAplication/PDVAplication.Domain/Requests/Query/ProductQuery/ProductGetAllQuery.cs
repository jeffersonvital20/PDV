using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Product;

namespace PDVAplication.Domain.Requests.Query.ProductQuery
{
    public class ProductGetAllQuery : IRequest<Result<List<ProductViewModel>>> , IValidatable
    {
    }
}
