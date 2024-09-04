using CentralBank.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {///Helllooooo
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);

        Task Delete(T entity);
        Task Add(T entity);
        Task Update(T entity);
    }
}
