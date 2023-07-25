using DataAccess.DataMapping;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.FluentValidations
{
    public class OrderAddressValidation:AbstractValidator<OrderAddress>
    {
        public OrderAddressValidation()
        {
            RuleFor(x => x.AddressName).MaximumLength(30).WithMessage("Maximum 30 Karakter Olabilir.");
            RuleFor(x => x.AddressName).MinimumLength(5).WithMessage("Minumum 5 Karakter Olabilir.");

            RuleFor(x => x.District).MaximumLength(50).WithMessage("Maximum 50 Karakter Olabilir.");
            RuleFor(x => x.District).MinimumLength(3).WithMessage("Minumum 3 Karakter Olabilir.");

            RuleFor(x => x.City).MaximumLength(50).WithMessage("Maximum 50 Karakter Olabilir.");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Minimum 3 Karakter Olabilir.");

            RuleFor(x => x.FullAddress).MaximumLength(350).WithMessage("Maximum 350 Karakter Olabilir.");
            RuleFor(x => x.FullAddress).MinimumLength(10).WithMessage("Minimum 10 Karakter Olabilir.");


        }
    }
}
