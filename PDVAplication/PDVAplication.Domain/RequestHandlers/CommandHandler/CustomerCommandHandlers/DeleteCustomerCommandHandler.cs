using MediatR;
using OperationResult;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Command.CustomerCommands;
using PDVAplication.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.CommandHandler.CustomerCommands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Result<bool>>
    {
        ICustomerRepository _customerRepository;
        public DeleteCustomerCommandHandler( ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<Result<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result =  _customerRepository.GetById(request.Id) ?? throw new ArgumentException("Customer not found");

                _customerRepository.Delete(result);
                return Result.Success(true);
            }
            catch (Exception ex)
            {
                return Result.Error<bool>(new ArgumentException(ex.Message));
            }
        }
    }
}
