using MediatR;
using OperationResult;
using PDVAplication.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Requests.Command.ProductCommands
{
    public class DeleteProductCommand : IRequest<Result<bool>>, IValidatable
    {
        public DeleteProductCommand(Guid id) => Id = id;
        public Guid Id { get; }
    }
}
