using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Command.CustomerCommands
{
    public class CreateCustomerCommand : IRequest<Result<CustomerViewModel>>, IValidatable
    {
        public CustomerViewModel Customer { get; set; }

        public CreateCustomerCommand(CustomerViewModel customer)
        {
            Customer = customer;
        }
    }
}
