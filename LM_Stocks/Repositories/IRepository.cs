using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LM_Stocks.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity, int id);
        bool Remove(int id);
        T Get(int id);
        IEnumerable<T> GetAll(); 
    }
}
