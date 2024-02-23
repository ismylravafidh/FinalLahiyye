using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
    public class Certificate:BaseEntity
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
