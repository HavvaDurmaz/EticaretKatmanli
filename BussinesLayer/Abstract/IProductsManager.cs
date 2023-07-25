using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IProductsManager
    {
        public IList<DTOProductsList> GetList();

        public Products GetById(int id);

        public dynamic UpdateData(Products data);

        public dynamic DeleteData(Products data);

        public dynamic AddData(Products data);
    }
}
