using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Command.ProductCommands
{
    public class CreateProductCommand : IRequest<Result<ProductViewModel>>, IValidatable
    {
        public ProductViewModel Product { get; set; }
        public CreateProductCommand(ProductViewModel product)
        {
            Product = product;
        }
    }
}
