using PDVAplication.Shared.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Shared.ViewModel.Sale
{
    public class UpdateProductSaleViewModel
    {
        public Guid IdSale { get; set; }
        public ICollection<ProductSoldViewModel>? Products { get; set; }
    }
}
