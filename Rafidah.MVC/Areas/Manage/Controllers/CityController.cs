using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.City;

namespace Rafidah.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CityController : Controller
    {
        ICityService _service;
        IMapper _mapper;
        public CityController(ICityService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var cities = await _service.GetAllAsync();
            return View(cities);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CityCreateVm cityVm)
        {
            if (!ModelState.IsValid)
            {
                return View(cityVm);
            }
            try
            {
                await _service.CreateAsync(cityVm);
                return RedirectToAction("Index", "City");
            }
            catch (NullException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View(cityVm);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                CityDetailVm city = await _service.GetByIdAsync(id);
                CityUpdateVm cityVm = _mapper.Map<CityUpdateVm>(city);
                return View(cityVm);
            }
            catch (InvalidIdException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(CityUpdateVm cityVm)
        {
            if (!ModelState.IsValid)
            {
                return View(cityVm);
            }
            try
            {
                await _service.UpdateAsync(cityVm);
                return RedirectToAction("Index", "City");
            }
            catch (NullException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
            catch (NotFoundException ex)
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
                return RedirectToAction("Index", "City");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
        }
        public async Task<IActionResult> ReverseDelete(int id)
        {
            try
            {
                await _service.ReverseDelete(id);
                return RedirectToAction("Index", "City");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
        }
    }
}
