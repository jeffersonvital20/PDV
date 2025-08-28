using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Query.ProductQuery;
using PDVAplication.Shared.ViewModel.Customer;
using PDVAplication.Shared.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.QueryHandler.ProductQueryHandlers
{
    public class ProductGetByIdQueryHandler : IRequestHandler<ProductGetByIdQuery, Result<ProductViewModel>>
    {
        IProductRepository _productRepository;
        IMapper _mapper;

        public ProductGetByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;   
            _productRepository = productRepository; 
        }

        public Task<Result<ProductViewModel>> Handle(ProductGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _productRepository.GetById(request.Id);
            if (result == null)
                return Result.Error<ProductViewModel>(new ArgumentException("Customer not found"));

            return Result.Success(_mapper.Map<ProductViewModel>(result));
        }
    }
}
