using FluentValidation;
using Rafidah.Business.ViewModels.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.Language
{
    public class LanguageCreateVm
    {
        public string LanguageName { get; set; }
    }
    public class LanguageCreateVmValidation : AbstractValidator<LanguageCreateVm>
    {
        public LanguageCreateVmValidation()
        {
            RuleFor(c => c.LanguageName)
                .NotEmpty()
                .WithMessage("Can not Language Name Null.")
                .MaximumLength(100)
                .WithMessage("Gender Name Maximum Length 100.");
        }
    }
}
