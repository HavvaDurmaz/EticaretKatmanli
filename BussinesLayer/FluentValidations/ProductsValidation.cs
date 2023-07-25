using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.FluentValidations
{
    public class ProductsValidation: AbstractValidator<Products>
    {
        public ProductsValidation() 
        {
            RuleFor(x => x.ProductsName).MinimumLength(0).WithMessage("Boş Bırakılamaz");
            RuleFor(x => x.ProductsName).MaximumLength(50).WithMessage("Maximum 50 Karakter Girilebilir");

            // Stock Değişkenine Atanan Değer 1'den Küçük İse Uyarı Verecek. 
            RuleFor(x => x.Stock).Must(x => x < 1).WithMessage("Stock Adeti 1'den Küçük Olamaz.");
            RuleFor(x => x.Price).Must(x => x != 0 ).WithMessage("Fiyat 0 Olamaz.");
            RuleFor(x => x.ProductsName).MaximumLength(350).WithMessage("Maximum 350 Karakter Girilebilir.");
        }
    }
}
