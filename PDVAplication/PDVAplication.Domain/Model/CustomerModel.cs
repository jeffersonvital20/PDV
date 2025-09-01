using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Model
{
    public class CustomerModel : BaseModel
    {
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? CPF { get; set; }
    }
}
