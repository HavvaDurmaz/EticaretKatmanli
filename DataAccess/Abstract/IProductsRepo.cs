using DataAccess.Repository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductsRepo:IRepositories<Products>
    {
        //Büyükten Küçüğe, Küçükten Büyüğe Sıralamak için

        public IList<Products> OrderBy(Expression<Func<Products, bool>> where);
    }
}
