using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
    public class Education:BaseEntity
    {
        public string Name { get; set; }
        public string UniversityName { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
