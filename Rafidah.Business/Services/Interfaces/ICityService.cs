using Rafidah.Business.ViewModels.Category;
using Rafidah.Business.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Interfaces
{
    public interface ICityService
    {
        Task<List<CityListVm>> GetAllAsync();
        Task CreateAsync(CityCreateVm cityVm);
        Task<CityDetailVm> GetByIdAsync(int id);
        Task UpdateAsync(CityUpdateVm cityVm);
        Task SoftDelete(int id);
        Task ReverseDelete(int id);
    }
}
