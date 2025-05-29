using Business;
using Microsoft.EntityFrameworkCore;
using Repository.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public  class GenericRepository<TEntity> where TEntity : class
    {
        private Context _context;
        private DbSet<TEntity> dbSet;
        public GenericRepository(Context context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity); 
        }

        public virtual List<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove (entity);
            
        }

        public virtual void Delete(int id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public virtual void Persist()
        {
            _context.SaveChanges();
        }
    }
}
