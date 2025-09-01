using Microsoft.EntityFrameworkCore;
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
        AppDbContext _context;
        public CustomerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public CustomerModel GetByCPF(string cpf)
        {
            return _context.Set<CustomerModel>().AsNoTracking().FirstOrDefault(c => c.CPF == cpf);
        }
    }
}
