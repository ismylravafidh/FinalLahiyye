using FluentValidation;
using Rafidah.Business.ViewModels.Base;
using Rafidah.Business.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.Country
{
    public class CountryUpdateVm:BaseEntityVm
    {
        public string CountryName { get; set; }
    }
    public class CountryUpdateVmValidation : AbstractValidator<CountryUpdateVm>
    {
        public CountryUpdateVmValidation()
        {
            RuleFor(c => c.CountryName)
                .NotEmpty()
                .WithMessage("Can not City Name Null.")
                .MaximumLength(200)
                .WithMessage("City Name Maximum Length 200.");
        }
    }
}
