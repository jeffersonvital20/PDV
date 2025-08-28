using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Query.CustomerQuery;
using PDVAplication.Shared.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.QueryHandler.CustomerQueryHandlers
{
    public class CustomerGetAllQueryHandler : IRequestHandler<CustomerGetAllQuery, Result<List<CustomerViewModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerGetAllQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public Task<Result<List<CustomerViewModel>>> Handle(CustomerGetAllQuery request, CancellationToken cancellationToken)
        {
            var result = _customerRepository.GetAll();
            if (result == null)
                return Result.Error<List<CustomerViewModel>>(new ArgumentException("Customer not found"));
            
            return Result.Success(_mapper.Map<List<CustomerViewModel>>(result));
        }
    }
}
