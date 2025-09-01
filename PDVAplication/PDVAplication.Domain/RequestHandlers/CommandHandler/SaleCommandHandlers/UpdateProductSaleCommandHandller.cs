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
    public class UpdateProductSaleCommandHandller : IRequestHandler<UpdateProductSaleCommand, Result<SaleViewModel>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;

        public UpdateProductSaleCommandHandller(
            ISalesRepository salesRepository, 
            IProductRepository productsRepository,
            IMapper mapper,
            IProductSaleRepository productSaleRepository,
            ILogger logger,
            ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _salesRepository = salesRepository;
            _productsRepository = productsRepository;
            _productSaleRepository = productSaleRepository;
            _logger = logger;
            _customerRepository = customerRepository;
        }

        public Task<Result<SaleViewModel>> Handle(UpdateProductSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sale = _salesRepository.GetById(request.Sale.IdSale);
                if (sale == null)
                    return Result.Error<SaleViewModel>(new ArgumentException("Sale not found"));
                foreach (var product in request.Sale.Products)
                {
                    var storageProduct = _productsRepository.GetById(product.Id);
                    if (storageProduct == null)
                        return Task.FromResult(Result.Error<SaleViewModel>(new ArgumentException("Product not found")));
                    if (product.Amount < 20)
                    {
                        //Adciona o produto a venda
                        sale.Products.Add(new ProductModel()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = storageProduct.Price,
                            Amount = product.Amount
                        });
                        var productSale = new ProductSaleModel();
                        
                        //Atualizar o stock
                        storageProduct.Amount -= product.Amount;
                        _productsRepository.Update(storageProduct);

                        //Aplicar o desconto
                        if (product.Amount > 9 && product.Amount < 21)
                        {
                            var valueProduct = product.Amount * storageProduct.Price;
                            var discountProduct = valueProduct * 0.2m;
                            sale.Discount += discountProduct;
                            var valueProductDiscount = valueProduct - discountProduct;

                            productSale.ProductId = product.Id;
                            productSale.SaleId = sale.Id;
                            productSale.QuantityProduct = product.Amount;
                            productSale.PriceProduct = valueProduct;
                            productSale.DiscountProduct = discountProduct;

                            sale.FinalValue += valueProductDiscount;
                        }
                        else if (product.Amount > 3 && product.Amount < 10)
                        {
                            var valueProduct = product.Amount * storageProduct.Price;
                            var discountProduct = valueProduct * 0.1m;
                            sale.Discount += discountProduct;
                            var valueProductDiscount = valueProduct - discountProduct;

                            productSale.ProductId = product.Id;
                            productSale.SaleId = sale.Id;
                            productSale.QuantityProduct = product.Amount;
                            productSale.PriceProduct = valueProduct;
                            productSale.DiscountProduct = discountProduct;

                            sale.FinalValue += valueProductDiscount;
                        }
                        else
                        {
                            var valueProduct = product.Amount * storageProduct.Price;

                            productSale.ProductId = product.Id;
                            productSale.SaleId = sale.Id;
                            productSale.QuantityProduct = product.Amount;
                            productSale.PriceProduct = valueProduct;
                            productSale.DiscountProduct = 0;

                            sale.FinalValue += valueProduct;
                        }

                        sale.Customer = _customerRepository.GetById(sale.CustomerId);
                        _productSaleRepository.Create(productSale);
                    }
                    else
                    {
                        return Result.Error<SaleViewModel>(new ArgumentException("The maximum quantity of a product per sale is 20 units"));
                    }


                }
                sale.SalesDate = DateTime.UtcNow;
                sale.SalesUpdateDate = DateTime.UtcNow;


                _salesRepository.Update(sale);
                _logger.LogInformation($"SaleModified ======== Products updated in sale {sale.Id} successfully. ========");

                var result = _salesRepository.GetById(sale.Id);
                var pr = _productSaleRepository.GetBySale(sale.Id);
                var listProducts = new List<ProductModel>();

                foreach (var item in pr)
                {
                    var product = _productsRepository.GetById(item.ProductId);
                    listProducts.Add(new ProductModel
                    {
                        Id = item.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Amount = item.QuantityProduct
                    });
                }                    

                result.Products = listProducts;
                return Result.Success(_mapper.Map<SaleViewModel>(result));

            }
            catch (Exception ex)
            {
                return Result.Error<SaleViewModel>(new ArgumentException(ex.Message));                
            }
        }
    }
}
