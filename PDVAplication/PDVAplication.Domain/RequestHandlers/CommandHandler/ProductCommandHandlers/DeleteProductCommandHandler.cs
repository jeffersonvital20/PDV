using MediatR;
using OperationResult;
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
    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<bool>>
    {
        IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<Result<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _productRepository.GetById(request.Id) ?? throw new ArgumentException("Product not found");

                _productRepository.Delete(result);
                return Result.Success(true);
            }
            catch (Exception ex)
            {
                return Result.Error<bool>(new ArgumentException(ex.Message));
            }
        }
    }
}
