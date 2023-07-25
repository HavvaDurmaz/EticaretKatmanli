using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Categories
    {
        public int id { get; set; }

        public string CategoryName { get; set; }

        public bool Status { get; set; }

        public int SubCategory { get; set; }

        // Her Bir Kategorinin Birden Fazla Ürünü Olabilir. ( Many To One İlişkilendirmesi. )

        public List<Products> Products { get; set; }
    }
}
