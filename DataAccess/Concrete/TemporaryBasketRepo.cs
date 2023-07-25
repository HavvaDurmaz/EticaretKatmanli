using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class TemporaryBasketRepo: Repositories<TemporaryBasket>, ITemporaryBasketRepo
    {
    }
}
