using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Command.CustomerCommands;
using PDVAplication.Shared.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.CommandHandler.CustomerCommands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CustomerViewModel>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Result<CustomerViewModel>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _mapper.Map<CustomerModel>(request.Customer);
                await _customerRepository.Create(customer).ConfigureAwait(false);

                var result = _customerRepository.GetById(customer.Id);

                return Result.Success(_mapper.Map<CustomerViewModel>(result));
            }
            catch (Exception ex)
            {
                return Result.Error<CustomerViewModel>(new ArgumentException(ex.Message));
            }
        }
    }
}
