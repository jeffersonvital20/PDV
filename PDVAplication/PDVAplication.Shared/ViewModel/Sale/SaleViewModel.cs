
using PDVAplication.Shared.ViewModel.Customer;
using PDVAplication.Shared.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Shared.ViewModel.Sale
{
    public class SaleViewModel
    {
        public Guid Id { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
        public CustomerViewModel Customer { get; set; }
        
        [Required]
        public DateTime SalesDate { get; set; }
        public DateTime SalesUpdateDate { get; set; }
        public DateTime SalesEndteDate { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalValue { get; set; }
        public string? Status { get; set; }
        public string? Branch { get; set; }
        public string? Seller { get; set; }
    }
}
