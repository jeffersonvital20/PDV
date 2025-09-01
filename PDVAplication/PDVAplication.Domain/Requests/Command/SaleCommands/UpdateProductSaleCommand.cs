using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Command.SaleCommands
{
    public class UpdateProductSaleCommand : IRequest<Result<SaleViewModel>>, IValidatable
    {
        public UpdateProductSaleViewModel Sale { get; set; }
        public UpdateProductSaleCommand(UpdateProductSaleViewModel sale)
        {
            Sale = sale;
        }
    }
}
