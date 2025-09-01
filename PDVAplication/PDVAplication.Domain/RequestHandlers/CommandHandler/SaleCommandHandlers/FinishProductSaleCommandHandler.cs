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
    public class FinishProductSaleCommandHandler : IRequestHandler<FinishProductSaleCommand, Result<SaleViewModel>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public FinishProductSaleCommandHandler(ISalesRepository salesRepository, IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _salesRepository = salesRepository;
            _logger = logger;
        }
        public Task<Result<SaleViewModel>> Handle(FinishProductSaleCommand request, CancellationToken cancellationToken)
        {
            var result = _salesRepository.GetById(request.Id.Id);
            if (result == null)
                return Result.Error<SaleViewModel>(new ArgumentException("Sale not found"));

            result.Status = "Finished";
            result.SalesEndteDate = DateTime.Now;

            _salesRepository.Update(result);
            _logger.LogInformation($"SaleModified ======== Sale finish ========");
            return Result.Success(_mapper.Map<SaleViewModel>(result));
        }
    }
}
