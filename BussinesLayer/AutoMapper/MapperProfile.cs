using AutoMapper;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.AutoMapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            //Products Sınıfının içindeki Dataları, DTOProducts içerisine aktaracaktır 
            CreateMap<Products, DTOProductsList>().ReverseMap();
            CreateMap<Categories, DTOCategories>().ReverseMap();
            CreateMap<Customers, DTOCustomers>().ReverseMap();

            //ReverseMap => Kod bloğunun sonunda bu kelimle var ise, Soldakini Sağa aktar ve Sağdakini Sola Aktarmamızı sağlar. Eğer bu kelime yok ise, Sadece Soldakini Sağa Aktarır.
        }
    }   
}
