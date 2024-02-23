using Rafidah.Business.ViewModels.Gender;
using Rafidah.Business.ViewModels.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<List<LanguageListVm>> GetAllAsync();
        Task CreateAsync(LanguageCreateVm languageVm);
        Task<LanguageDetailVm> GetByIdAsync(int id);
        Task UpdateAsync(LanguageUpdateVm languageVm);
        Task SoftDelete(int id);
        Task ReverseDelete(int id);
    }
}
