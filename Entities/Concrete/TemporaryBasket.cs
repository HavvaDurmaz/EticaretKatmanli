using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TemporaryBasket
    {
        public int Id { get; set; } 

        public int ProductsId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }  

        public string ImagesHome { get; set; }  

        public int CookieID { get; set; }
        public int Piece { get; set; }
    }
}
