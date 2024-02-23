using Microsoft.Extensions.DependencyInjection;
using Rafidah.Business.Services.Implementations;
using Rafidah.Business.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Business
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<ILanguageService, LanguageService>();
        }
    }
}
