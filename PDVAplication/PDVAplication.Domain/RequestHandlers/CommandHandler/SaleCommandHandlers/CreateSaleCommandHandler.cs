using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Command.SaleCommands;
using PDVAplication.Shared.ViewModel.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.CommandHandler.SaleCommandHandlers
{
    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, Result<SaleViewModel>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        public CreateSaleCommandHandler(ISalesRepository salesRepository, IMapper mapper, ILogger logger, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _salesRepository = salesRepository;
            _logger = logger;
            _customerRepository = customerRepository;
        }
        public async Task<Result<SaleViewModel>> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _customerRepository.GetByCPF(request.Sale.Customer.CPF);
                if (customer == null)
                    return Result.Error<SaleViewModel>(new ArgumentException("Customer not found"));
                var insert = new SalesModel()
                {
                    CustomerId = customer.Id,
                    SalesDate = DateTime.UtcNow,
                    Status = "InProgress",
                    Branch = request.Sale.Branch,
                    Seller = request.Sale.Seller,
                };
                await _salesRepository.Create(insert).ConfigureAwait(false);

                _logger.LogInformation($"SaleCreated ======== New Sale Created ========");

                var result = _salesRepository.GetById(insert.Id);
                result.Customer = customer;
                return Result.Success(_mapper.Map<SaleViewModel>(result));

            }
            catch (Exception ex)
            {
                return Result.Error<SaleViewModel>(new ArgumentException(ex.Message));
            }
        }
    }
}
