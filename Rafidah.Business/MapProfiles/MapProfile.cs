using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rafidah.Business.ViewModels.Category;
using Rafidah.Business.ViewModels.City;
using Rafidah.Business.ViewModels.Country;
using Rafidah.Business.ViewModels.Gender;
using Rafidah.Business.ViewModels.Language;
using Rafidah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business.MapProfiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CategoryCreateVm, Category>().ReverseMap();
            CreateMap<CategoryDetailVm, Category>().ReverseMap();
            CreateMap<CategoryListVm, Category>().ReverseMap();
            CreateMap<CategoryDetailVm, CategoryUpdateVm>().ReverseMap();
            CreateMap<CategoryUpdateVm,Category>().ReverseMap();

            CreateMap<CityCreateVm, City>().ReverseMap();
            CreateMap<CityDetailVm, City>().ReverseMap();
            CreateMap<CityListVm, City>().ReverseMap();
            CreateMap<CityDetailVm, CityUpdateVm>().ReverseMap();
            CreateMap<CityUpdateVm, City>().ReverseMap();

            CreateMap<CountryCreateVm, Country>().ReverseMap();
            CreateMap<CountryDetailVm, Country>().ReverseMap();
            CreateMap<CountryListVm, Country>().ReverseMap();
            CreateMap<CountryDetailVm, CountryUpdateVm>().ReverseMap();
            CreateMap<CountryUpdateVm, Country>().ReverseMap();

            CreateMap<GenderCreateVm, Gender>().ReverseMap();
            CreateMap<GenderDetailVm, Gender>().ReverseMap();
            CreateMap<GenderListVm, Gender>().ReverseMap();
            CreateMap<GenderDetailVm, GenderUpdateVm>().ReverseMap();
            CreateMap<GenderUpdateVm, Gender>().ReverseMap();

            CreateMap<LanguageCreateVm, Language>().ReverseMap();
            CreateMap<LanguageDetailVm, Language>().ReverseMap();
            CreateMap<LanguageListVm, Language>().ReverseMap();
            CreateMap<LanguageDetailVm, LanguageUpdateVm>().ReverseMap();
            CreateMap<LanguageUpdateVm, Language>().ReverseMap();


        }
    }
}
