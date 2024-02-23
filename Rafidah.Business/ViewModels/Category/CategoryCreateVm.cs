using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.ViewModels.Category
{
    public class CategoryCreateVm
    {
        public string CategoryName { get; set; }
    }
    public class CategoryCreateVmValidation : AbstractValidator<CategoryCreateVm>
    {
        public CategoryCreateVmValidation()
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
