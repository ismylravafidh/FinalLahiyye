using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
	public class Country:BaseEntity
	{
		public string CountryName { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
