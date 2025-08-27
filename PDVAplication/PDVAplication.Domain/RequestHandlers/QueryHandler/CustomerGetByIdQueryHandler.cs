using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Query;
using PDVAplication.Shared.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.QueryHandler
{
    public class CustomerGetByIdQueryHandler : IRequestHandler<CustomerGetByIdQuery, Result<CustomerByIdViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerGetByIdQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public Task<Result<CustomerByIdViewModel>> Handle(CustomerGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _customerRepository.GetById(request.Id);
            if (result == null) 
                return Result.Error<CustomerByIdViewModel>(new ArgumentException("Customer not found"));

            return Result.Success(_mapper.Map<CustomerByIdViewModel>(result));
        }
    }
}
