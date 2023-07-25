using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public interface IOrdersManager
    {
        public IList<Orders> GetList();

        public Orders GetByID(int id);

        public dynamic AddData(Orders orders, List<OrderDetails> details, OrderAddress adress);

        public dynamic UpdateData(Orders orders);
    }
}
