using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.Language;

namespace Rafidah.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class LanguageController : Controller
    {
        ILanguageService _service;
        IMapper _mapper;
        public LanguageController(ILanguageService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var languages = await _service.GetAllAsync();
            return View(languages);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageCreateVm languageVm)
        {
            if (!ModelState.IsValid)
            {
                return View(languageVm);
            }
            try
            {
                await _service.CreateAsync(languageVm);
                return RedirectToAction("Index", "Language");
            }
            catch (NullException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View(languageVm);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                LanguageDetailVm language = await _service.GetByIdAsync(id);
                LanguageUpdateVm languageVm = _mapper.Map<LanguageUpdateVm>(language);
                return View(languageVm);
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
        public async Task<IActionResult> Update(LanguageUpdateVm languageVm)
        {
            if (!ModelState.IsValid)
            {
                return View(languageVm);
            }
            try
            {
                await _service.UpdateAsync(languageVm);
                return RedirectToAction("Index", "Language");
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
                return RedirectToAction("Index", "Language");
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
                return RedirectToAction("Index", "Language");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
        }
    }
}
