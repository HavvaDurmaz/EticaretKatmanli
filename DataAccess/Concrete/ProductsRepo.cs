using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProductsRepo: Repositories<Products>, IProductsRepo 
    {
        public IList<Products> OrderBy(Expression<Func<Products, bool>> where)
        {
            return GetAll().OrderBy(x => x.Price).ToList();
        }
    }
}
