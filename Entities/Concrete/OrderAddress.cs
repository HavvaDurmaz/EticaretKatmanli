using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderAddress
    {
        public int Id { get; set; } 

        public int CookieID { get; set; }

        public string AddressName { get; set; }

        public int CustomersId { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string FullAddress { get; set; }

        public bool AddressType { get; set; } // Fatura Adresimi ya da Teslimat Adresimi olduğunu anlayabilmek adına 

        public Customers Customers { get; set; }

        public Orders Orders { get; set; }
    }
}
