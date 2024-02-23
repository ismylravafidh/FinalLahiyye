using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public List<AppUser>? AppUsers { get; set; }
        public List<Job>? Jobs { get; set; }
    }
}
