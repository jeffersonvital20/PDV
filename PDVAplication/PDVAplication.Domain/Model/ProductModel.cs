using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Model
{
    public class ProductModel : BaseModel
    {
        public ProductModel()
        {
            Sales = new Collection<SalesModel>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ICollection<SalesModel> Sales { get; set; }
    }
}
