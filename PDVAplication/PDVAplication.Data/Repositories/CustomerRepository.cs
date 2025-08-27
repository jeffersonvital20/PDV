using PDVAplication.Data.Context;
using PDVAplication.Domain.Model;
using PDVAplication.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Data.Repositories
{
    public class CustomerRepository : BaseRepository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
