using FluentValidation;
using Rafidah.Business.ViewModels.Base;
using Rafidah.Business.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.City
{
    public class CityUpdateVm:BaseEntityVm
    {
        public string CityName { get; set; }
    }
    public class CityUpdateVmValidation : AbstractValidator<CityUpdateVm>
    {
        public CityUpdateVmValidation()
        {
            RuleFor(c => c.CityName)
                .NotEmpty()
                .WithMessage("Can not City Name Null.")
                .MaximumLength(200)
                .WithMessage("City Name Maximum Length 200.");
        }
    }
}
