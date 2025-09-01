using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Query.SaleQuery;
using PDVAplication.Shared.ViewModel.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.QueryHandler.SaleQueryHandlers
{
    public class SaleGetByIdQueryHandler : IRequestHandler<SaleGetByIdQuery, Result<SaleViewModel>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        public SaleGetByIdQueryHandler(ISalesRepository salesRepository, IMapper mapper, IProductSaleRepository productSaleRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _salesRepository = salesRepository;
            _productSaleRepository = productSaleRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }
        public Task<Result<SaleViewModel>> Handle(SaleGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultSale = _salesRepository.GetById(request.Id);

                if (resultSale == null)
                    return Result.Error<SaleViewModel>(new ArgumentException("Sale not found"));

                var pr = _productSaleRepository.GetBySale(request.Id);
                var listProducts = new List<ProductModel>();
                foreach (var item in pr)
                {
                    var product = _productRepository.GetById(item.ProductId);
                    listProducts.Add(new ProductModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Amount = item.QuantityProduct
                    });
                }

                resultSale.Products = listProducts;
                resultSale.Customer = _customerRepository.GetById(resultSale.CustomerId);

                return Result.Success(_mapper.Map<SaleViewModel>(resultSale));

            }
            catch (Exception ex)
            {
                return Result.Error<SaleViewModel>(new ArgumentException(ex.Message));
            }
        }
    }
}
