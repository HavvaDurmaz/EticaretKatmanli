using DataAccess.Abstract;
using DataAccess.Repository;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CategoriesRepo : Repositories<Categories>, ICategoriesRepo
    {

    }
}
