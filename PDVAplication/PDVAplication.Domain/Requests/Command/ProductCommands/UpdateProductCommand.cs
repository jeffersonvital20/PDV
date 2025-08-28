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
    public class UpdateProductCommand : IRequest<Result<bool>>, IValidatable
    {
        public ProductViewModel product { get; set; }
        public UpdateProductCommand( ProductViewModel productViewModel) => this.product = productViewModel;
       
    }
}
