using BussinesLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrete
{
    public class OrdersManager : IOrdersManager
    {
        private readonly IOrdersRepo ordersRepo;
        private readonly IOrderDetailsRepo detailsRepo;
        private readonly IOrderAddressRepo addressRepo;

        public OrdersManager (IOrdersRepo _ordersRepo, IOrderAddressRepo _addressRepo, IOrderDetailsRepo _detailsRepo)
        {
            ordersRepo = _ordersRepo;
            detailsRepo = _detailsRepo;
            addressRepo = _addressRepo;
        }
        public dynamic AddData(Orders orders, List<OrderDetails> details, OrderAddress adress)
        {

            Random rnd = new Random(); // Sipariş Numarası Üretmek için 
            int SiparisNo = rnd.Next(0, 999999);
            while (ordersRepo.GetByFirst(x=>x.CookieId == SiparisNo) != null)
            {
                SiparisNo = rnd.Next(0, 999999);
            }
            orders.CookieId = SiparisNo;           
            adress.CookieID = SiparisNo;

            ordersRepo.Add(orders);

            foreach (var item in details)
            {
                item.CookieId = SiparisNo;
                detailsRepo.Add(item);
            }
           
            return addressRepo.Add(adress);
        }

        public Orders GetByID(int id)
        {
            var BulunanOrders = ordersRepo.GetByFirst(x=>x.CookieId ==id);
            foreach (var item in detailsRepo.GetAll(x=>x.CookieId == BulunanOrders.CookieId))
            {
                BulunanOrders.OrderDetails.Add(item);
            }
            foreach (var item in addressRepo.GetAll(x => x.CookieID == BulunanOrders.CookieId))
            {
                BulunanOrders.OrderAddress.Add(item);   
            }
            return BulunanOrders;
        }

        public IList<Orders> GetList()
        {
            return ordersRepo.GetAll();
        }

        public dynamic UpdateData(Orders orders)
        {
            return ordersRepo.Update(orders);
        }
    }
}
