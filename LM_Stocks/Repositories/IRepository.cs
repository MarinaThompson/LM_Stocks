using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LM_Stocks.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        bool Remove(T entity);
        T Get(int id);
        IEnumerable<T> GetAll(); 
    }
}
