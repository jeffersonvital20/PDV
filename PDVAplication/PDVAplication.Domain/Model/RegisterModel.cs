using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string? Name { get; set; }
        
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "password is required")]
        public string? Password { get; set; }
    }
}
