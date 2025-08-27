using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.CommandHandler
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<bool>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public Task<Result<bool>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _mapper.Map<CustomerModel>(request.Customer);

                _customerRepository.Update(customer);
                return Result.Success(true);
            }
            catch (Exception ex)
            {
                return Result.Error<bool>(new ArgumentException(ex.Message));
            }
                
        }
    }
}
