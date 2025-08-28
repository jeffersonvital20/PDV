using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Query.ProductQuery
{
    public class ProductGetByIdQuery : IRequest<Result<ProductViewModel>> , IValidatable
    {
        public Guid Id { get; set; }
        public ProductGetByIdQuery(Guid Id) => this.Id = Id;
    }
}
