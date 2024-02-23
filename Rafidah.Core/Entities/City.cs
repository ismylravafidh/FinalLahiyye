using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
	public class City : BaseEntity
	{
		public string CityName { get; set; }
		public List<AppUser> AppUsers { get; set; }
	}
}
