using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Repositories<TEntity> : IRepositories<TEntity> where TEntity : class
    {
        public dynamic Add(TEntity entity)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<TEntity>().Add(entity);
                    db.SaveChanges();
                    return new string[] { "1", "İşlem Başarılı" };
                }
                catch (Exception e)
                {
                    return new string[] { "1", e.Message };
                }
            }           
        }

        public dynamic Delete(TEntity entity)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<TEntity>().Remove(entity);
                    db.SaveChanges();
                    return new string[] { "1", "İşlem Başarılı" };
                }
                catch (Exception e)
                {
                    return new string[] { "1", e.Message };
                }
            }
        }

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                if(where == null)
                {
                    return db.Set<TEntity>().AsNoTracking().ToList();   
                }
                else
                {
                    return db.Set<TEntity>().Where(where).AsNoTracking().ToList();
                }
            }
        }

        public TEntity GetByFirst(Expression<Func<TEntity, bool>> where)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Set<TEntity>().Where(where).AsNoTracking().FirstOrDefault();

                // First => Data kesinlikle olmalı
                // FirstOrDefault => Data olması gerekmiyor 
            }
        }

        public dynamic Update(TEntity entity)
        {
            using(DatabaseContext db = new DatabaseContext())
            {
                try
                {
                    db.Set<TEntity>().Update(entity);
                    db.SaveChanges() ;
                    return new string[] { "0", ",İşlem Başarılı" };
                }
                catch(Exception e)
                {
                    return new string[] { "1", e.Message };
                }
            }
        }
    }
}
