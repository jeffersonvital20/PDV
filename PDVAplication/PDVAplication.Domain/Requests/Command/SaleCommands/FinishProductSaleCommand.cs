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
    public class FinishProductSaleCommand : IRequest<Result<SaleViewModel>>, IValidatable
    {
        public StatusSaleProductViewModel Id { get; set; }
        public FinishProductSaleCommand(StatusSaleProductViewModel id)
        {
            Id = id;
        }
    }
}
