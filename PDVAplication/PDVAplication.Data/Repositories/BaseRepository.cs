using Microsoft.EntityFrameworkCore;
using PDVAplication.Data.Context;
using PDVAplication.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context) => _context = context;

        public async Task Create(T create)
        {
            await _context.Set<T>().AddAsync(create);
            Save();
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            Save();
        }

        public IQueryable<T> GetAll()
    => _context.Set<T>().AsNoTracking();

        public T GetById(Guid id)
        {
            return _context.Set<T>()
                               .AsNoTracking()
                               .FirstOrDefault(e => EF.Property<Guid>(e, "Id") == id);
        }

        public void Save() => _context.SaveChanges();

        public void Update(T update)
        {
            var local = _context.Set<T>()
         .Local
         .FirstOrDefault(e => EF.Property<Guid>(e, "Id")
                           == EF.Property<Guid>(update, "Id"));

            if (local != null)
            {
                _context.Entry(local).CurrentValues.SetValues(update);
            }
            else
            {
                _context.Entry(update).State = EntityState.Modified;
            }
            // _context.Set<T>().Update(update);
            Save();
        }
    }
}
