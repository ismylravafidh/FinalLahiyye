using FluentValidation;
using Rafidah.Business.ViewModels.Base;
using Rafidah.Business.ViewModels.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.Language
{
    public class LanguageUpdateVm:BaseEntityVm
    {
        public string LanguageName { get; set; }
    }
    public class LanguageUpdateVmValidation : AbstractValidator<LanguageUpdateVm>
    {
        public LanguageUpdateVmValidation()
        {
            RuleFor(c => c.LanguageName)
                .NotEmpty()
                .WithMessage("Can not Language Name Null.")
                .MaximumLength(100)
                .WithMessage("Language Name Maximum Length 100.");
        }
    }
}
