using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rafidah.Business.Exceptions.Common;
using Rafidah.Business.Services.Interfaces;
using Rafidah.Business.ViewModels.Gender;

namespace Rafidah.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class GenderController : Controller
    {
        IGenderService _service;
        IMapper _mapper;
        public GenderController(IGenderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _service.GetAllAsync();
            return View(categories);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GenderCreateVm GenderVm)
        {
            if (!ModelState.IsValid)
            {
                return View(GenderVm);
            }
            try
            {
                await _service.CreateAsync(GenderVm);
                return RedirectToAction("Index", "Gender");
            }
            catch (NullException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View(GenderVm);
            }
        }
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                GenderDetailVm Gender = await _service.GetByIdAsync(id);
                GenderUpdateVm GenderVm = _mapper.Map<GenderUpdateVm>(Gender);
                return View(GenderVm);
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
        public async Task<IActionResult> Update(GenderUpdateVm GenderVm)
        {
            if (!ModelState.IsValid)
            {
                return View(GenderVm);
            }
            try
            {
                await _service.UpdateAsync(GenderVm);
                return RedirectToAction("Index", "Gender");
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
                return RedirectToAction("Index", "Gender");
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
                return RedirectToAction("Index", "Gender");
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", ex.ErrorMessage);
                return View();
            }
        }
    }
}
