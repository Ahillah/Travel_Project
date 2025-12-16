using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
         Task<bool> SaveChangesAsync();
    }
}
