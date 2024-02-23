using Rafidah.Business.ViewModels.Category;
using Rafidah.Business.ViewModels.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Interfaces
{
    public interface ICountryService
    {
        Task<List<CountryListVm>> GetAllAsync();
        Task CreateAsync(CountryCreateVm countryVm);
        Task<CountryDetailVm> GetByIdAsync(int id);
        Task UpdateAsync(CountryUpdateVm countryVm);
        Task SoftDelete(int id);
        Task ReverseDelete(int id);
    }
}
