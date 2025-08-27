using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDVAplication.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
        Task Create(T create);
        void Update(T update);
        void Delete(T item);
        void Save();
    }
}
