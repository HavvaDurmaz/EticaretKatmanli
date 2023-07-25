using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.FluentValidations
{
    public class CustomerValidation : AbstractValidator<Customers>
    {
        public CustomerValidation() 
        {
            RuleFor(x => x.NameSurName).MaximumLength(50).WithMessage("Maximum 50 Karakter Girilebilir.");
            RuleFor(x => x.NameSurName).MinimumLength(5).WithMessage("Minimum 5 Karakter Girilebilir.");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Maximum 50 Karakter Girilebilir.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli Mail Adresi Girmediniz.");
            RuleFor(x => x.Passwords).MaximumLength(15).WithMessage("Maximum 15 Karakter Girilebilir.");
            RuleFor(x => x.Passwords).MinimumLength(8).WithMessage("Minumum 8 Karakter Girilebilir.");
        }
    }        
}
