using FluentValidation;
using Rafidah.Business.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.Category
{
    public class CategoryUpdateVm:BaseEntityVm
    {
        public string CategoryName { get; set; }
    }
    public class CategoryUpdateVmValidation : AbstractValidator<CategoryUpdateVm>
    {
        public CategoryUpdateVmValidation()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty()
                .WithMessage("Can not Category Name Null.")
                .MinimumLength(3)
                .WithMessage("Category Name Minimum Length 3.")
                .MaximumLength(200)
                .WithMessage("Category Name Maximum Length 200.");
        }
    }
}
