using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
	public class Gender:BaseEntity
	{
		public string GenderName { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
