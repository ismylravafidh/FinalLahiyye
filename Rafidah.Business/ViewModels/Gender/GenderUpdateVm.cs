using FluentValidation;
using Rafidah.Business.ViewModels.Base;
using Rafidah.Business.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.Gender
{
    public class GenderUpdateVm:BaseEntityVm
    {
        public string GenderName { get; set; }
    }
    public class GenderUpdateVmValidation : AbstractValidator<GenderUpdateVm>
    {
        public GenderUpdateVmValidation()
        {
            RuleFor(c => c.GenderName)
                .NotEmpty()
                .WithMessage("Can not Gender Name Null.")
                .MaximumLength(30)
                .WithMessage("Gender Name Maximum Length 30.");
        }
    }
}
