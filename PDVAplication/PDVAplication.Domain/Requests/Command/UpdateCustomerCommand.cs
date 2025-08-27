using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using PDVAplication.Shared.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Command
{
    public class UpdateCustomerCommand : IRequest<Result<bool>>, IValidatable
    {
        public UpdateCustomerCommand(CustomerByIdViewModel customer)
        {
            Customer = customer;
        }
        public CustomerByIdViewModel Customer { get; }
    }
}
