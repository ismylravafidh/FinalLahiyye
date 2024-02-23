using AutoMapper;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.Category;
using Rafidah.Business.ViewModels.City;
using Rafidah.Core.Entities;
using Rafidah.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Implementations
{
    public class CityService:ICityService
    {
        ICityRepository _repo;
        IMapper _mapper;
        public CityService(ICityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CityListVm>> GetAllAsync()
        {
            IQueryable<City> cities = await _repo.GetAllAsync();
            List<CityListVm> result = new List<CityListVm>();
            foreach (var city in cities)
            {
                var c = _mapper.Map<CityListVm>(city);
                result.Add(c);
            }
            return result;
        }

        public async Task<CityDetailVm> GetByIdAsync(int id)
        {
            if (id <= 0) throw new InvalidIdException();
            City city = await _repo.GetByIdAsync(id);
            if (city == null) throw new NotFoundException();
            return _mapper.Map<CityDetailVm>(city);
        }
        public async Task CreateAsync(CityCreateVm cityVm)
        {
            if (cityVm == null) throw new NullException();

            City city = _mapper.Map<City>(cityVm);

            await _repo.CreateAsync(city);
            await _repo.SaveChangesAsync();
        }
        public async Task UpdateAsync(CityUpdateVm cityVm)
        {
            if (cityVm == null) throw new NullException();
            City oldCity = await _repo.GetByIdAsync(cityVm.Id);
            if (oldCity == null) throw new NotFoundException();
            _mapper.Map(cityVm, oldCity);
            await _repo.Update(oldCity);
            await _repo.SaveChangesAsync();
        }
        public async Task SoftDelete(int id)
        {
            City city = await _repo.GetByIdAsync(id);
            if (city == null) throw new NotFoundException();
            city.IsDeleted = true;
            await _repo.SoftDelete(city);
            await _repo.SaveChangesAsync();
        }
        public async Task ReverseDelete(int id)
        {
            City city = await _repo.GetByIdAsync(id);
            if (city == null) throw new NotFoundException();
            await _repo.ReverseDelete(city);
            await _repo.SaveChangesAsync();
        }
    }
}
