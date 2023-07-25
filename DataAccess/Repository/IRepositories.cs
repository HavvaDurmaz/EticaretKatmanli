using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepositories<TEntity> where TEntity: class
    {
        public dynamic Add(TEntity entity);

        public dynamic Update(TEntity entity);

        public dynamic Delete(TEntity entity);

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null);
       

        public TEntity GetByFirst(Expression<Func<TEntity, bool>> where);

        // Eğer Bir Filtreleme uygulanmak isteniyorsa, Dinamik Filtreleme MEtot'u aktif edilir. Yani Belirtilen Tabloya göre Filtre yazılacağı sisteme söylenir.
        //Expression<Func<TEntity, bool>> where => Tablo Bazlı Where Sorgusu Yazdırır.
        // db.Categories.Where(x=> x.CategoryName = 'qweq');
        // db.Products.where(x=> x.ProductName = 'qweqw')
    }
}
