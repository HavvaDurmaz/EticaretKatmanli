using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface ICategoriesManager
    {
        public IList<DTOCategories> GetList();

        public Categories GetById(int id);

        public dynamic UpdateData(Categories data);

        public dynamic DeleteData(Categories data);

        public dynamic AddData(Categories data);

        public List<Products> GetCategoriesProducts(int CategoriesId);  
    }
}
