using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class OrdersRepo: Repositories<Orders>,IOrdersRepo
    {
    }
}
