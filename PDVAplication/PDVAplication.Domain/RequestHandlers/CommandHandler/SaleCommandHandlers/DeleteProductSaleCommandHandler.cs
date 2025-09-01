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
    public class DeleteProductSaleCommandHandler : IRequestHandler<DeleteProductSaleCommand, Result<SaleViewModel>>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productsRepository;
        private readonly IMapper _mapper;
        private readonly IProductSaleRepository _productSaleRepository;
        private readonly ILogger _logger;

        public DeleteProductSaleCommandHandler(
            ISalesRepository salesRepository,
            IProductRepository productsRepository,
            IMapper mapper,
            IProductSaleRepository productSaleRepository,
            ILogger logger)
        {
            _mapper = mapper;
            _salesRepository = salesRepository;
            _productsRepository = productsRepository;
            _productSaleRepository = productSaleRepository;
            _logger = logger;
        }

        public Task<Result<SaleViewModel>> Handle(DeleteProductSaleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productSale = _productSaleRepository.GetByProductAndSale(request.Id.ProductId, request.Id.SaleId);
                var sale = _salesRepository.GetById(request.Id.SaleId);
                if (sale == null)
                    return Result.Error<SaleViewModel>(new ArgumentException("Sale not found"));

                //Atualizar o stock
                var productUpdateStock = _productsRepository.GetById(request.Id.ProductId);
                productUpdateStock.Amount += productSale.QuantityProduct;
                _productsRepository.Update(productUpdateStock);

                //remove o produto da venda
                _productSaleRepository.Delete(productSale);

                //Atualiza o valor final da venda
                sale.SalesUpdateDate = DateTime.UtcNow;
                sale.FinalValue = sale.FinalValue - (productSale.PriceProduct + productSale.DiscountProduct);

                _salesRepository.Update(sale);

                _logger.LogInformation($"SaleModified ======== ItemCancelled. ========");

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
