using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class OrderDetails
    {
        public int Id { get; set; }

        public int CookieId { get; set; }

        public int ProductsId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }  

        public int Piece { get; set; }

        public string ImagesHome { get; set; }

        // Her  Bir Ürünün Bir Ordersı Olmak Zorunda. ( One To One )

        public Orders Orders { get; set;}
    }
}
