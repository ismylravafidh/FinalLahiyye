using Rafidah.Business.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryListVm>> GetAllAsync();
        Task CreateAsync(CategoryCreateVm categoryVm);
        Task<CategoryDetailVm> GetByIdAsync(int id);
        Task UpdateAsync(CategoryUpdateVm categoryVm);
        Task SoftDelete(int id);
        Task ReverseDelete(int id);
    }
}
