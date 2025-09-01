using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Command.SaleCommands;
using PDVAplication.Shared.ViewModel.Sale;

namespace PDVAplication.Domain.RequestHandlers.CommandHandler.SaleCommandHandlers
{
    public class CancelSaleCommandHandler : IRequestHandler<CancelSaleCommand, Result<SaleViewModel>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        public CancelSaleCommandHandler(ISalesRepository salesRepository, IMapper mapper)
        {
            _mapper = mapper;
            _salesRepository = salesRepository;
        }
        public Task<Result<SaleViewModel>> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var result = _salesRepository.GetById(request.IdSale.Id);
            if (result == null)
                return Result.Error<SaleViewModel>(new ArgumentException("Sale not found"));

            result.Status = "Cancel";
            result.SalesEndteDate = DateTime.Now;

            _salesRepository.Update(result);
            return Result.Success(_mapper.Map<SaleViewModel>(result));
        }
    }
}
