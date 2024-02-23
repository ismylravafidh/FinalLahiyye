using AutoMapper;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.Category;
using Rafidah.Core.Entities;
using Rafidah.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _repo;
        IMapper _mapper;
        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CategoryListVm>> GetAllAsync()
        {
            IQueryable<Category> categories = await _repo.GetAllAsync();
            List<CategoryListVm> result = new List<CategoryListVm>();
            foreach (var category in categories)
            {
                var c = _mapper.Map<CategoryListVm>(category);
                result.Add(c);
            }
            return result;
        }

        public async Task<CategoryDetailVm> GetByIdAsync(int id)
        {
            if (id <= 0) throw new InvalidIdException();
            Category category = await _repo.GetByIdAsync(id);
            if(category == null) throw new NotFoundException();
            return _mapper.Map<CategoryDetailVm>(category);
        }
        public async Task CreateAsync(CategoryCreateVm categoryVm)
        {
            if (categoryVm == null) throw new NullException();

            Category category = _mapper.Map<Category>(categoryVm);

            await _repo.CreateAsync(category);
            await _repo.SaveChangesAsync();
        }
        public async Task UpdateAsync(CategoryUpdateVm categoryVm)
        {
            if (categoryVm == null) throw new NullException();
            Category oldCategory = await _repo.GetByIdAsync(categoryVm.Id);
            if (oldCategory == null) throw new NotFoundException();
            _mapper.Map(categoryVm, oldCategory);
            await _repo.Update(oldCategory);
            await _repo.SaveChangesAsync();
        }
        public async Task SoftDelete(int id)
        {
            Category category =await _repo.GetByIdAsync(id);
            if (category == null) throw new NotFoundException();
            category.IsDeleted = true;
            await _repo.SoftDelete(category);
            await _repo.SaveChangesAsync();
        }
        public async Task ReverseDelete(int id)
        {
            Category category = await _repo.GetByIdAsync(id);
            if(category == null) throw new NotFoundException();
            await _repo.ReverseDelete(category);
            await _repo.SaveChangesAsync();
        }
    }
}
