using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Model
{
    public class ProductSaleModel: BaseModel
    {
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ForeignKey("Sale")]
        public Guid SaleId { get; set; }
        public int QuantityProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public decimal DiscountProduct { get; set; }
    }
}
