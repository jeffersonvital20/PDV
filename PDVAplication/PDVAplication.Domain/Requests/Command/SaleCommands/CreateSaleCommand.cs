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
    public class CreateSaleCommand : IRequest<Result<SaleViewModel>>, IValidatable
    {
        public InitialSaleViewModel Sale { get; set; }
        public CreateSaleCommand(InitialSaleViewModel sale)
        {
            Sale = sale;
        }
        
    }    
}
  