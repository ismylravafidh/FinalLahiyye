using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
    public class Job:BaseEntity
    {
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Money { get; set; }
        public string Days { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
