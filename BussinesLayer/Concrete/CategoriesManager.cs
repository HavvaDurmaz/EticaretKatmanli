using AutoMapper;
using BussinesLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class CategoriesManager : ICategoriesManager
    {
        // Readonly=> İstenilen yapıyı asadece yapıcı metot ile kullanmamızı sağlar
        private readonly ICategoriesRepo repo;
        private readonly IMapper mapper;
        private readonly IProductsRepo productsManager;

        public CategoriesManager(ICategoriesRepo _repo, IMapper _mapper, IProductsRepo _productsManager)
        {
            repo = _repo;
            mapper = _mapper;
            productsManager = _productsManager;
        }

        public dynamic AddData(Categories data)
        {
            return repo.Add(data);
        }

        public dynamic DeleteData(Categories data)
        {
            return repo.Delete(data);
        }

        public Categories GetById(int id)
        {
           return repo.GetByFirst(x=> x.id == id);
        }

        public IList<DTOCategories> GetList()
        {
            return mapper.Map<IList<DTOCategories>>(repo.GetAll());
        }

        public dynamic UpdateData(Categories data)
        {
            return repo.Update(data);
        }

        public List<Products> GetCategoriesProducts(int CategoriesId)
        {
            return productsManager.GetAll().Where(x=> x.CategoriesId == CategoriesId).ToList();
        }
    }
}
