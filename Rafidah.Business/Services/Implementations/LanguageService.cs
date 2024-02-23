using AutoMapper;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.Language;
using Rafidah.Core.Entities;
using Rafidah.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepository _repo;
        IMapper _mapper;
        public LanguageService(ILanguageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<LanguageListVm>> GetAllAsync()
        {
            IQueryable<Language> languages = await _repo.GetAllAsync();
            List<LanguageListVm> result = new List<LanguageListVm>();
            foreach (var language in languages)
            {
                var l = _mapper.Map<LanguageListVm>(language);
                result.Add(l);
            }
            return result;
        }

        public async Task<LanguageDetailVm> GetByIdAsync(int id)
        {
            if (id <= 0) throw new InvalidIdException();
            Language language = await _repo.GetByIdAsync(id);
            if (language == null) throw new NotFoundException();
            return _mapper.Map<LanguageDetailVm>(language);
        }
        public async Task CreateAsync(LanguageCreateVm languageVm)
        {
            if (languageVm == null) throw new NullException();

            Language language = _mapper.Map<Language>(languageVm);

            await _repo.CreateAsync(language);
            await _repo.SaveChangesAsync();
        }
        public async Task UpdateAsync(LanguageUpdateVm languageVm)
        {
            if (languageVm == null) throw new NullException();
            Language oldLanguage = await _repo.GetByIdAsync(languageVm.Id);
            if (oldLanguage == null) throw new NotFoundException();
            _mapper.Map(languageVm, oldLanguage);
            await _repo.Update(oldLanguage);
            await _repo.SaveChangesAsync();
        }
        public async Task SoftDelete(int id)
        {
            Language language = await _repo.GetByIdAsync(id);
            if (language == null) throw new NotFoundException();
            language.IsDeleted = true;
            await _repo.SoftDelete(language);
            await _repo.SaveChangesAsync();
        }
        public async Task ReverseDelete(int id)
        {
            Language language = await _repo.GetByIdAsync(id);
            if (language == null) throw new NotFoundException();
            await _repo.ReverseDelete(language);
            await _repo.SaveChangesAsync();
        }
    }
}
