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
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQuery, Result<List<ProductViewModel>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductGetAllQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public Task<Result<List<ProductViewModel>>> Handle(ProductGetAllQuery request, CancellationToken cancellationToken)
        {
            var result = _productRepository.GetAll();
            if (result == null)
                return Result.Error<List<ProductViewModel>>(new ArgumentException("Customer not found"));

            return Result.Success(_mapper.Map<List<ProductViewModel>>(result));
        }
    }
}
