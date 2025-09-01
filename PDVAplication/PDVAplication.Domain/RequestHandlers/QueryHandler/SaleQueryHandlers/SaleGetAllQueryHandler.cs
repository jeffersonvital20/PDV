using AutoMapper;
using MediatR;
using OperationResult;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;
using PDVAplication.Domain.Requests.Query.SaleQuery;
using PDVAplication.Shared.ViewModel.Product;
using PDVAplication.Shared.ViewModel.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.RequestHandlers.QueryHandler.SaleQueryHandlers
{
    public class SaleGetAllQueryHandler : IRequestHandler<SaleGetAllQuery, Result<List<SaleViewModel>>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMapper _mapper;
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public SaleGetAllQueryHandler(ISalesRepository salesRepository, IMapper mapper, IProductSaleRepository productSaleRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _salesRepository = salesRepository;
            _productSaleRepository = productSaleRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }
        public Task<Result<List<SaleViewModel>>> Handle(SaleGetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var resultSale = _salesRepository.GetAll().ToList();

                if (resultSale == null)
                    return Result.Error<List<SaleViewModel>>(new ArgumentException("Sale not found"));


                List<SalesModel> result = new List<SalesModel>();

                foreach (var sale in resultSale)
                {
                    var pr = _productSaleRepository.GetBySale(sale.Id);
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

                    sale.Products = listProducts;
                    sale.Customer = _customerRepository.GetById(sale.CustomerId);
                    result.Add(sale);
                }                

                return Result.Success(_mapper.Map<List<SaleViewModel>>(result));

            }
            catch (Exception ex)
            {
                return Result.Error<List<SaleViewModel>>(new ArgumentException(ex.Message));
            }
        }
    }
}
