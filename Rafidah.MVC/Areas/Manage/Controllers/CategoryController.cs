using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.Category;

namespace Rafidah.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        ICategoryService _service;
        IMapper _mapper;
        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories =await _service.GetAllAsync();
            return View(categories);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateVm categoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVm);
            }
            try
            {
                await _service.CreateAsync(categoryVm);
                return RedirectToAction("Index", "Category");
            }
            catch (NullException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View(categoryVm);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                CategoryDetailVm category = await _service.GetByIdAsync(id);
                CategoryUpdateVm categoryVm = _mapper.Map<CategoryUpdateVm>(category);
                return View(categoryVm);
            }
            catch(InvalidIdException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
            catch(NotFoundException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateVm categoryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryVm);
            }
            try
            {
                await _service.UpdateAsync(categoryVm);
                return RedirectToAction("Index", "Category");
            }
            catch (NullException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
            catch(NotFoundException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _service.SoftDelete(id);
                return RedirectToAction("Index", "Category");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("",ex.ErrorMessage);
                return View();
            }
        }
        public async Task<IActionResult> ReverseDelete(int id)
        {
            try
            {
                await _service.ReverseDelete(id);
                return RedirectToAction("Index", "Category");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("",ex.ErrorMessage);
                return View();
            }
        }
    }
}
