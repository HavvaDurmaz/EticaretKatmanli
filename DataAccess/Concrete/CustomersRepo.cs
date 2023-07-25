using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CustomersRepo :Repositories<Customers>, ICustomersRepo
    {
        public Customers Login (string Email, string Sifre)
        {
            return GetAll(x => x.Passwords == Sifre && x.Email == Email).FirstOrDefault();
        }
    }
}
