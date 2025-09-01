using Microsoft.EntityFrameworkCore;
using PDVAplication.Data.Context;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;

namespace PDVAplication.Data.Repositories
{
    public class ProductSaleRepository : BaseRepository<ProductSaleModel>, IProductSaleRepository
    {
        private readonly AppDbContext _context;
        public ProductSaleRepository(Context.AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ProductSaleModel GetByProductAndSale(Guid ProductId, Guid SaleId)
        {
            return _context.Set<ProductSaleModel>()
                                .AsNoTracking()
                                .FirstOrDefault(x => x.ProductId == ProductId && x.SaleId == SaleId);
        }

        public  List<ProductSaleModel> GetBySale(Guid SaleId)
        {
            var r =  _context.Set<ProductSaleModel>()
                                .AsNoTracking()
                                .Where(x => x.SaleId == SaleId);
            return r.ToList();
        }
    }
}
