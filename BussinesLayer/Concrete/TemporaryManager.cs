using AutoMapper;
using BussinesLayer.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BussinesLayer.Concrete
{
    public class TemporaryManager : ITemporaryManager
    {
        private readonly ITemporaryBasketRepo repo;
        public TemporaryManager(ITemporaryBasketRepo _repo)
        {
            repo = _repo;
        }
        public dynamic AddData(TemporaryBasket data)
        {

            // Sepet'e eklenmek istenen ürün daha önce sepete eklenmiş ise Adeti'ni arttırsın
            var BulunanUrun = repo.GetByFirst(x => x.CookieID == data.CookieID && x.ProductsId == data.ProductsId);
            if (BulunanUrun != null)
            {

                BulunanUrun.Piece += 1;
                return repo.Update(BulunanUrun);
            }
            else
            {
                return repo.Add(data);
            }
        }
        public IList<TemporaryBasket> GetList(int cookieId)
        {
            return repo.GetAll(x => x.CookieID == cookieId);
        }

        public dynamic UpdateData(int TemporaryId, bool ArttirmaEksiltme)
        {

            var BulunanUrun = repo.GetByFirst(x => x.Id == TemporaryId);
            // ArttirmaEksiltme => True ise Adet Arttırılacak, False ise Adet Azaltılacak.
            if (ArttirmaEksiltme)
            {
                BulunanUrun.Piece += 1;
                return repo.Update(BulunanUrun);
            }
            else
            {
                if (BulunanUrun.Piece > 1)
                {
                    BulunanUrun.Piece -= 1;
                    return repo.Update(BulunanUrun);
                }
                else
                {
                    return repo.Delete(BulunanUrun);
                }
            }
        }

        public dynamic DeleteData(TemporaryBasket data)
        {
            return repo.Delete(data);
        }
    }
}
