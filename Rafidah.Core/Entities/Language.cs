using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.Core.Entities
{
	public class Language:BaseEntity
	{
		public string LanguageName { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
