using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface ITemporaryManager
    {
        public IList<TemporaryBasket> GetList(int cookieId);      

        public dynamic UpdateData(int TemporaryId, bool ArttirmaEksiltme);
      
        public dynamic AddData(TemporaryBasket data);

        public dynamic DeleteData(TemporaryBasket data);
    }
}
