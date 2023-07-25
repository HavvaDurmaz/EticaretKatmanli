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
    public class ProductsManager : IProductsManager
    {

        private readonly IProductsRepo repo;
        private readonly IMapper mapper;

        public ProductsManager(IProductsRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }


        public dynamic AddData(Products data)
        {
            return repo.Add(data);
        }

        public dynamic DeleteData(Products data)
        {
            return repo.Delete(data);
        }

        public Products GetById(int id)
        {
            return repo.GetByFirst(x=> x.Id == id);
        }

        public IList<DTOProductsList> GetList()
        {
            return mapper.Map<IList<DTOProductsList>>(repo.GetAll());
        }

        public dynamic UpdateData(Products data)
        {
            return repo.Update(data);
        }
    }
}
