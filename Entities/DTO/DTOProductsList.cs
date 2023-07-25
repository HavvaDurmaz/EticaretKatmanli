using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class DTOProductsList
    {
        public int Id { get; set; }

        public string ProductsName { get; set; }      

        public decimal Price { get; set; }    

        public string ImagesHome { get; set; }
    }
}
