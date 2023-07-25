using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.FluentValidations
{
    public class CategoriesValidation: AbstractValidator<Categories>
    {
        public CategoriesValidation() 
        {
            RuleFor(x => x.CategoryName).MinimumLength(0).WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Maximum 50 Karakter Girilebilir");
        }
    }
}
