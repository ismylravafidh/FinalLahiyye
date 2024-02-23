using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.Gender
{
    public class GenderCreateVm
    {
        public string GenderName { get; set; }
    }
    public class GenderCreateVmValidation : AbstractValidator<GenderCreateVm>
    {
        public GenderCreateVmValidation()
        {
            RuleFor(c => c.GenderName)
                .NotEmpty()
                .WithMessage("Can not Gender Name Null.")
                .MaximumLength(30)
                .WithMessage("Gender Name Maximum Length 30.");
        }
    }
}
