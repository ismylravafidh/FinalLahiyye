using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public int? HourlyRateId { get; set; }
        public HourlyRate? HourlyRate { get; set; }
        public int? GenderId { get; set; }
        public Gender? Gender { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public int? LanguageId { get; set; }
        public Language? Languages { get; set; }
        public int? LanguageLevelId { get; set; }
        public LanguageLevel? LanguagesLevel { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Education>? Educations { get; set; }
        public List<WorkAndExperience>? WorkAndExperiences { get; set; }
        public List<Certificate>? Certificates { get; set; }
        public List<Job>? Jobs { get; set; }
    }
}
