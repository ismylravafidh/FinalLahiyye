using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.Country;

namespace Rafidah.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CountryController : Controller
    {
        ICountryService _service;
        IMapper _mapper;
        public CountryController(ICountryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var countries = await _service.GetAllAsync();
            return View(countries);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CountryCreateVm countryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(countryVm);
            }
            try
            {
                await _service.CreateAsync(countryVm);
                return RedirectToAction("Index", "Country");
            }
            catch (NullException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View(countryVm);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                CountryDetailVm country = await _service.GetByIdAsync(id);
                CountryUpdateVm countryVm = _mapper.Map<CountryUpdateVm>(country);
                return View(countryVm);
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
        public async Task<IActionResult> Update(CountryUpdateVm countryVm)
        {
            if (!ModelState.IsValid)
            {
                return View(countryVm);
            }
            try
            {
                await _service.UpdateAsync(countryVm);
                return RedirectToAction("Index", "Country");
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
                return RedirectToAction("Index", "Country");
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
                return RedirectToAction("Index", "Country");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
        }
    }
}
