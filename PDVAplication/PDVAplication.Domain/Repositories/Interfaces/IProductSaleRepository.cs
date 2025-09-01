using PDVAplication.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Repositories.Interfaces
{
    public interface IProductSaleRepository :IBaseRepository<ProductSaleModel>
    {
        ProductSaleModel GetByProductAndSale(Guid ProductId, Guid SaleId);
        List<ProductSaleModel> GetBySale(Guid SaleId);
    }
}
