using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Command.ProductCommands;
using PDVAplication.Shared.ViewModel.Customer;
using PDVAplication.Shared.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.CommandHandler.ProductCommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Result<ProductViewModel>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var insert = _mapper.Map<ProductModel>(request.Product);
                await _productRepository.Create(insert).ConfigureAwait(false);

                var result = _productRepository.GetById(insert.Id);
                return Result.Success(_mapper.Map<ProductViewModel>(result));
            }
            catch (Exception ex)
            {
                return Result.Error<ProductViewModel>(new ArgumentException(ex.Message));
            }
        }
    }
}
