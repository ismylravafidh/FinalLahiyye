using Microsoft.Extensions.DependencyInjection;
using Rafidah.DAL.Repositories.Implementations;
using Rafidah.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.DAL
{
    public static class ServiceRegistration
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
        }
    }
}
