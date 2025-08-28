using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Command.CustomerCommands;
using PDVAplication.Domain.Requests.Command.ProductCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.CommandHandler.ProductCommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<bool>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<Result<bool>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<ProductModel>(request.product);

                _repository.Update(product);
                return Result.Success(true);
            }
            catch (Exception ex)
            {
                return Result.Error<bool>(new ArgumentException(ex.Message));
            }

        }
    }
}
