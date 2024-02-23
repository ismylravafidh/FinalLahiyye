using FluentValidation;
using Rafidah.Business.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.Country
{
    public class CountryCreateVm
    {
        public string CountryName { get; set; }
    }
    public class CountryCreateVmValidation : AbstractValidator<CountryCreateVm>
    {
        public CountryCreateVmValidation()
        {
            RuleFor(c => c.CountryName)
                .NotEmpty()
                .WithMessage("Can not Country Name Null.")
                .MaximumLength(200)
                .WithMessage("Country Name Maximum Length 200.");
        }
    }
}
