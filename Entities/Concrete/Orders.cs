using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Orders
    {
     

        public int CookieId { get; set; }

        public decimal TotalPrice { get; set; }

        public string PaymentType { get; set; }

        public DateTime PaymentDate { get; set; }

        public int CustomersId { get; set; }

        public string OrderStatus { get; set; }

        public string CargoNumber { get; set; }

        // Her Bir Orderın Birden Fazla OrderDetailsi Olmak Zordundadır. ( Many To One )

        public List<OrderDetails> OrderDetails { get; set; }

        public List <OrderAddress> OrderAddress { get; set; }
    }
}
