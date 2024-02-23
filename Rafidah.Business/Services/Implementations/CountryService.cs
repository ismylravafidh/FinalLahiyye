using AutoMapper;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.City;
using Rafidah.Business.ViewModels.Country;
using Rafidah.Core.Entities;
using Rafidah.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Implementations
{
    public class CountryService:ICountryService
    {
        ICountryRepository _repo;
        IMapper _mapper;
        public CountryService(ICountryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CountryListVm>> GetAllAsync()
        {
            IQueryable<Country> countries = await _repo.GetAllAsync();
            List<CountryListVm> result = new List<CountryListVm>();
            foreach (var country in countries)
            {
                var c = _mapper.Map<CountryListVm>(country);
                result.Add(c);
            }
            return result;
        }

        public async Task<CountryDetailVm> GetByIdAsync(int id)
        {
            if (id <= 0) throw new InvalidIdException();
            Country country = await _repo.GetByIdAsync(id);
            if (country == null) throw new NotFoundException();
            return _mapper.Map<CountryDetailVm>(country);
        }
        public async Task CreateAsync(CountryCreateVm countryVm)
        {
            if (countryVm == null) throw new NullException();

            Country country = _mapper.Map<Country>(countryVm);

            await _repo.CreateAsync(country);
            await _repo.SaveChangesAsync();
        }
        public async Task UpdateAsync(CountryUpdateVm countryVm)
        {
            if (countryVm == null) throw new NullException();
            Country oldCountry = await _repo.GetByIdAsync(countryVm.Id);
            if (oldCountry == null) throw new NotFoundException();
            _mapper.Map(countryVm, oldCountry);
            await _repo.Update(oldCountry);
            await _repo.SaveChangesAsync();
        }
        public async Task SoftDelete(int id)
        {
            Country country = await _repo.GetByIdAsync(id);
            if (country == null) throw new NotFoundException();
            country.IsDeleted = true;
            await _repo.SoftDelete(country);
            await _repo.SaveChangesAsync();
        }
        public async Task ReverseDelete(int id)
        {
            Country country = await _repo.GetByIdAsync(id);
            if (country == null) throw new NotFoundException();
            await _repo.ReverseDelete(country);
            await _repo.SaveChangesAsync();
        }
    }
}
