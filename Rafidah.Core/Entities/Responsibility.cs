using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
    public class Responsibility:BaseEntity
    {
        public AppUser User { get; set; }
        public string Responsibilities { get; set; }
        public int? JobId { get; set; }
        public Job? Job { get; set; }
    }
}
