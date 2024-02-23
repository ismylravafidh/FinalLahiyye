using AutoMapper;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.City;
using Rafidah.Business.ViewModels.Country;
using Rafidah.Business.ViewModels.Gender;
using Rafidah.Core.Entities;
using Rafidah.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Implementations
{
    public class GenderService:IGenderService
    {
        IGenderRepository _repo;
        IMapper _mapper;
        public GenderService(IGenderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GenderListVm>> GetAllAsync()
        {
            IQueryable<Gender> genders = await _repo.GetAllAsync();
            List<GenderListVm> result = new List<GenderListVm>();
            foreach (var gender in genders)
            {
                var g = _mapper.Map<GenderListVm>(gender);
                result.Add(g);
            }
            return result;
        }

        public async Task<GenderDetailVm> GetByIdAsync(int id)
        {
            if (id <= 0) throw new InvalidIdException();
            Gender gender = await _repo.GetByIdAsync(id);
            if (gender == null) throw new NotFoundException();
            return _mapper.Map<GenderDetailVm>(gender);
        }
        public async Task CreateAsync(GenderCreateVm genderVm)
        {
            if (genderVm == null) throw new NullException();

            Gender gender = _mapper.Map<Gender>(genderVm);

            await _repo.CreateAsync(gender);
            await _repo.SaveChangesAsync();
        }
        public async Task UpdateAsync(GenderUpdateVm genderVm)
        {
            if (genderVm == null) throw new NullException();
            Gender oldGender = await _repo.GetByIdAsync(genderVm.Id);
            if (oldGender == null) throw new NotFoundException();
            _mapper.Map(genderVm, oldGender);
            await _repo.Update(oldGender);
            await _repo.SaveChangesAsync();
        }
        public async Task SoftDelete(int id)
        {
            Gender gender = await _repo.GetByIdAsync(id);
            if (gender == null) throw new NotFoundException();
            gender.IsDeleted = true;
            await _repo.SoftDelete(gender);
            await _repo.SaveChangesAsync();
        }
        public async Task ReverseDelete(int id)
        {
            Gender gender = await _repo.GetByIdAsync(id);
            if (gender == null) throw new NotFoundException();
            await _repo.ReverseDelete(gender);
            await _repo.SaveChangesAsync();
        }
    }
}
