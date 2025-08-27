using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Model
{
    public class SalesModel : BaseModel
    {
        public SalesModel()
        {
            Products = new Collection<ProductModel>();
        }
        [Required]
        public ICollection<ProductModel> Products { get; set; }
        public CustomerModel Customer { get; set; }
        [Required]
        public DateTime SalesDate { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalValue { get; set; }
        public string Status { get; set; }
    }
}
