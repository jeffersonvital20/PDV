using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Command.CustomerCommands
{
    public class DeleteCustomerCommand : IRequest<Result<bool>>, IValidatable
    {
        public DeleteCustomerCommand(Guid id) => Id = id;
        public Guid Id { get; }
    }
}
