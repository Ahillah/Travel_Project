using DomainLayer;
using DomainLayer.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task Add(TEntity entity)
        {
            await dbContext.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            dbContext.Remove(entity);
        }

   

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
          return  await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

      

        public async Task<bool> SaveChangesAsync()
        {
           return await  dbContext.SaveChangesAsync()>0;
        }

        public void Update(TEntity entity)
        {
            dbContext.Update(entity);
        }
    }
}
