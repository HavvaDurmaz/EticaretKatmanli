using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Products
    {
        public int Id { get; set; }

        public string ProductsName { get; set; }

        public string Explanation { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ImagesHome { get; set; }

        public string ImagesDetail { get; set; }

        public string ImagesDetail1 { get; set; }

        public string ImagesDetail2 { get; set; }

        public string ImagesDetail3 { get; set; }

        public int CategoriesId { get; set; }

        // Her Bir Ürünün 1 Adet Kategorisi Olacaktır.( One To One İlişkilendirmesi. )

        public Categories Categories { get; set; }
    }
}
