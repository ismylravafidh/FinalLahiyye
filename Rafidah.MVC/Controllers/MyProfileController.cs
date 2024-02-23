using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rafidah.Core.Entities;
using Rafidah.DAL.Context;
using Rafidah.MVC.ViewModels;
using System.Security.Claims;

namespace Rafidah.MVC.Controllers
{
	public class MyProfileController : Controller
	{
		AppDbContext _context;
		IHttpContextAccessor _contextAccessor;
		string userId;
		UserManager<AppUser> _userManager;
		SignInManager<AppUser> _signInManager;
		public MyProfileController(AppDbContext context, IHttpContextAccessor contextAccessor, UserManager<AppUser> userManager = null, SignInManager<AppUser> signInManager = null)
		{
			_context = context;
			userId = contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
            ViewBag.Gender = _context.Genders.ToList();
            ViewBag.Country = _context.Countries.ToList();
            ViewBag.City = _context.Cities.ToList();
            ViewBag.Language = _context.Languages.ToList();
            ViewBag.LanguageLevel = _context.LanguageLevels.ToList();
			ViewBag.HourlyRate=_context.HourlyRates.ToList();
			ViewBag.Skill=_context.Categories.ToList();
			var r=_context.Users.Where(u => u.Id == userId).FirstOrDefault();
			HomeVm homeVm = new HomeVm()
			{
				AppUser = _context.Users.Where(u=>u.Id==userId).FirstOrDefault(),
				Education=_context.Educations.Where(e=>e.AppUserId==userId).ToList(),
				WorkAndExperience=_context.WorkAndExperiences.Where(e=>e.AppUserId==userId).ToList(),
				Certificate=_context.Certificates.Where(e=>e.AppUserId==userId).ToList(),
			};
			return View(homeVm);
		}
		[HttpPost]
		public IActionResult Update(HomeVm user)
		{
			ViewBag.Gender = _context.Genders.ToList();
			ViewBag.Country = _context.Countries.ToList();
			ViewBag.City = _context.Cities.ToList();
			ViewBag.Language = _context.Languages.ToList();
			ViewBag.LanguageLevel = _context.LanguageLevels.ToList();
			ViewBag.HourlyRate = _context.HourlyRates.ToList();
			ViewBag.Skill = _context.Categories.ToList();
			var oldUser = _context.Users.FirstOrDefault(x => x.Id == userId);
			oldUser.UserName = user.AppUser.UserName;
			oldUser.GenderId = user.AppUser.GenderId;
			oldUser.HourlyRateId=user.AppUser.HourlyRateId;
			oldUser.Description = user.AppUser.Description;
			oldUser.PhoneNumber = user.AppUser.PhoneNumber;
			oldUser.Email = user.AppUser.Email;
			oldUser.CityId = user.AppUser.CityId;
			oldUser.CountryId = user.AppUser.CountryId;
			oldUser.LanguageId = user.AppUser.LanguageId;
			oldUser.LanguageLevelId = user.AppUser.LanguageLevelId;
			oldUser.CategoryId = user.AppUser.CategoryId;
			_context.Users.Update(oldUser);

			_context.SaveChanges();
            return RedirectToAction("Index","MyProfile");
		}
		//[HttpPost]
		//public IActionResult Education(HomeVm vm) 
		//{
		//	List<Education> es = _context.Educations.Where(e=>e.AppUserId==userId).ToList();
		//	var d=es.LastOrDefault(es=>es.AppUserId==userId).Id;
		//	for(Education i=es.Where(e => e.AppUserId == userId).FirstOrDefault() ;i.Id<=d;i.Id++)
		//	{
		//		i.Name = vm.Education.Where(b => b.Id == i.Id).FirstOrDefault().Name;
		//		i.UniversityName = vm.Education.Where(b => b.Id == i.Id).FirstOrDefault().UniversityName;
		//		i.Time = vm.Education.Where(b => b.Id == i.Id).FirstOrDefault().Time;
		//		i.Description = vm.Education.Where(b => b.Id == i.Id).FirstOrDefault().Description;
		//		_context.Educations.Update(i);
		//	}
		//	_context.SaveChanges();
		//	return RedirectToAction("Index","MyProfile"); 
		//}
		public IActionResult CreateEducation()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateEducation(Education education)
		{
			education.AppUserId = userId;
			_context.Educations.Add(education);
			_context.SaveChanges();
			return RedirectToAction("Index","MyProfile");
		}
		public IActionResult EditEducation(int id)
		{
			var education = _context.Educations.Where(e => e.Id == id).FirstOrDefault();
			var model = new EditEducationVm
			{
				Id=id,
				Name = education.Name,
				UniversityName = education.UniversityName,
				Time = education.Time,
				Description = education.Description,
			};
			return View(model);
		}
        [HttpPost]
        public IActionResult EditEducation(EditEducationVm model,int id)
         {
			Education education = _context.Educations.Where(e => e.Id == id).FirstOrDefault();
			education.Name=model.Name;
			education.UniversityName=model.UniversityName;
			education.Time=model.Time;
			education.Description=model.Description;
			_context.Educations.Update(education);
			_context.SaveChanges();
            return RedirectToAction("Index","MyProfile");
        }
		public IActionResult DeleteEducation(int id)
		{
			Education education = _context.Educations.Where(e=>e.Id == id).FirstOrDefault();
			_context.Educations.Remove(education);
			_context.SaveChanges();
			return RedirectToAction("Index","MyProfile");
		}
		//[HttpPost]
		//public IActionResult Experience(HomeVm vm)
		//{
		//	List<WorkAndExperience> es = _context.WorkAndExperiences.Where(e => e.AppUserId == userId).ToList();
		//	var d = es.LastOrDefault(es => es.AppUserId == userId).Id;
		//	for (WorkAndExperience i = es.Where(e => e.AppUserId == userId).FirstOrDefault(); i.Id <= d; i.Id++)
		//	{
		//		i.Name = vm.WorkAndExperience.Where(b => b.Id == i.Id).FirstOrDefault().Name;
		//		i.CompanyName = vm.WorkAndExperience.Where(b => b.Id == i.Id).FirstOrDefault().CompanyName;
		//		i.Time = vm.WorkAndExperience.Where(b => b.Id == i.Id).FirstOrDefault().Time;
		//		i.Description = vm.WorkAndExperience.Where(b => b.Id == i.Id).FirstOrDefault().Description;
		//		_context.WorkAndExperiences.Update(i);
		//	}
		//	_context.SaveChanges();
		//	return RedirectToAction("Index", "MyProfile");
		//}
		public IActionResult CreateExperience()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateExperience(WorkAndExperience experience)
		{
			experience.AppUserId = userId;
			_context.WorkAndExperiences.Add(experience);
			_context.SaveChanges();
			return RedirectToAction("Index", "MyProfile");
		}
		public IActionResult EditExperience(int id)
		{
			WorkAndExperience experience = _context.WorkAndExperiences.Where(e => e.Id == id).FirstOrDefault();
			var model = new EditExperienceVm
			{
				Id = id,
				Name = experience.Name,
				CompanyName = experience.CompanyName,
				Time = experience.Time,
				Description = experience.Description,
			};
			return View(model);
		}
		[HttpPost]
		public IActionResult EditExperience(EditExperienceVm model)
		{
			WorkAndExperience experience = _context.WorkAndExperiences.Where(e => e.Id == model.Id).FirstOrDefault();
			experience.Name = model.Name;
			experience.CompanyName = model.CompanyName;
			experience.Time = model.Time;
			experience.Description = model.Description;
			_context.WorkAndExperiences.Update(experience);
			_context.SaveChanges();
			return RedirectToAction("Index", "MyProfile");
		}
		public IActionResult DeleteExperience(int id)
		{
			WorkAndExperience experience = _context.WorkAndExperiences.Where(e => e.Id == id).FirstOrDefault();
			_context.WorkAndExperiences.Remove(experience);
			_context.SaveChanges();
			return RedirectToAction("Index", "MyProfile");
		}
		public IActionResult CreateCertificate()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateCertificate(Certificate certificate)
		{
			certificate.AppUserId = userId;
			_context.Certificates.Add(certificate);
			_context.SaveChanges();
			return RedirectToAction("Index", "MyProfile");
		}
		public IActionResult EditCertificate(int id)
		{
			Certificate certificate = _context.Certificates.Where(e => e.Id == id).FirstOrDefault();
			var model = new EditCertificateVm
			{
				Id = id,
				Name = certificate.Name,
				CompanyName = certificate.CompanyName,
				Time = certificate.Time,
				Description = certificate.Description,
			};
			return View(model);
		}
		[HttpPost]
		public IActionResult EditCertificate(EditCertificateVm model)
		{
			Certificate certificate = _context.Certificates.Where(e => e.Id == model.Id).FirstOrDefault();
			certificate.Name = model.Name;
			certificate.CompanyName = model.CompanyName;
			certificate.Time = model.Time;
			certificate.Description = model.Description;
			_context.Certificates.Update(certificate);
			_context.SaveChanges();
			return RedirectToAction("Index", "MyProfile");
		}
		public IActionResult DeleteCertificate(int id)
		{
			Certificate certificate = _context.Certificates.Where(e => e.Id == id).FirstOrDefault();
			_context.Certificates.Remove(certificate);
			_context.SaveChanges();
			return RedirectToAction("Index", "MyProfile");
		}
		public async Task<IActionResult> ChangePassword(string password , string newPassword , string confirmPassword)
		{
			AppUser user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
			if (confirmPassword != newPassword)
			{
				ModelState.AddModelError("", "yeni Sifr uygun deyil");
				return RedirectToAction("Index","MyProfile");
			}
			var check = await _userManager.ChangePasswordAsync(user, password, newPassword);
			if (check.Succeeded)
			{
				return RedirectToAction("Index", "MyProfile");
			}
			return RedirectToAction("Index","MyProfile");
		}
		public async Task<IActionResult> DeleteProfile(string password)
		{
			AppUser user = _userManager.Users.FirstOrDefault(x=>x.Id == userId);
			var check = await _userManager.CheckPasswordAsync(user, password);
			if (check == false)
			{
				ModelState.AddModelError("", "UserName/Email or Password incorrect");
				return View(password);
			}
			await _userManager.DeleteAsync(user);
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
