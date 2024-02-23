using Rafidah.Core.Entities;
using Rafidah.DAL.Context;
using Rafidah.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.DAL.Repositories.Implementations
{
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        public GenderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
