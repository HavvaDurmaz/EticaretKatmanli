using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Abstract
{
    public  interface ICustomersManager
    {
        public IList<DTOCustomers> GetList();

        public Customers GetById(int id);

        public dynamic UpdateData(Customers data);

        public dynamic DeleteData(Customers data);

        public dynamic AddData(Customers data);

        public Customers Login(string email, string sifre);
    }
}
