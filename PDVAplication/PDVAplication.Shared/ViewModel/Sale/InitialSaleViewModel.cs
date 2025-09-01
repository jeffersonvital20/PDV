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
    public class InitialSaleViewModel
    {
        public InitialSaleViewModel()
        {
            Customer = new CustomerViewModel();
        }
        public CustomerViewModel Customer { get; set; }      
        public string? Branch { get; set; }
        public string? Seller { get; set; }
    }
}
