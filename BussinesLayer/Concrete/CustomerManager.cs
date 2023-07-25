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
    public class CustomerManager : ICustomersManager
    {
        private readonly ICustomersRepo repo;
        private readonly IMapper mapper;

        public CustomerManager(ICustomersRepo _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }


        public dynamic AddData(Customers data)
        {
            return repo.Add(data);
        }

        public dynamic DeleteData(Customers data)
        {
            return repo.Delete(data);
        }

        public Customers GetById(int id)
        {
            return repo.GetByFirst(x=>x.Id == id);  
        }

        public IList<DTOCustomers> GetList()
        {
            return mapper.Map<IList<DTOCustomers>>(repo.GetAll());
        }

        public dynamic UpdateData(Customers data)
        {
            return repo.Update(data);
        }

        public Customers Login(string email, string sifre)
        {
            return repo.Login(email, sifre);    
        }
    }
}
