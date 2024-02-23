using Rafidah.Business.ViewModels.Category;
using Rafidah.Business.ViewModels.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Interfaces
{
    public interface IGenderService
    {
        Task<List<GenderListVm>> GetAllAsync();
        Task CreateAsync(GenderCreateVm genderVm);
        Task<GenderDetailVm> GetByIdAsync(int id);
        Task UpdateAsync(GenderUpdateVm genderVm);
        Task SoftDelete(int id);
        Task ReverseDelete(int id);
    }
}
