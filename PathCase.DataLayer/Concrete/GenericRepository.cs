using Microsoft.EntityFrameworkCore;
using PathCase.DataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.DataLayer.Concrete
{
    public class GenericRepository<TEntity, TDbContext> : IRepositoryBase<TEntity> where TEntity : class where TDbContext : DbContext, new()
    {
        public List<TEntity> GetAll()
        {
            using var dbContext = new TDbContext();
            return dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetOne(int id)
        {
            using var dbContext = new TDbContext();
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            using var dbContext = new TDbContext();
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var dbContext = new TDbContext();
            dbContext.Set<TEntity>().Remove(entity);
            dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            using var dbContext = new TDbContext();
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
