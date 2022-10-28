using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {       
        Task<T> AddAsync(T entity);   
        Task<T> UpdateAsync(T entity);
        Task<bool> Exists(int id);
    }
}
