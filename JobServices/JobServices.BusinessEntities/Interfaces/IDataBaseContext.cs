using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.BusinessEntities.Interfaces
{
    public interface IDataBaseContext<T> where T : EntityBase
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> List();
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);
        Task<T> Create(T entity);
        Task<T> Delete(T entity);
        Task<T> Update(T entity);

    }

    public abstract class EntityBase
    {
        public int Id
        {
            get; protected set;
        }
    }
}
