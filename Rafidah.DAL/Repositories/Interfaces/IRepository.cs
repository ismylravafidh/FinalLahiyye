using Microsoft.EntityFrameworkCore;
using Rafidah.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rafidah.DAL.Repositories.Interfaces
{
    public interface IRepository<Entity> where Entity : BaseEntity, new()
    {
        Task<IQueryable<Entity>> GetAllAsync(Expression<Func<Entity, bool>>? expression = null,
                Expression<Func<Entity, object>>? orderbyExpression = null,
                bool isDescinding = false,
                params string[]? includes);
        Task<Entity> GetByIdAsync(int id);
        Task CreateAsync(Entity entity);
        Task Update(Entity entity);
        Task ReverseDelete(Entity entity);
        Task SoftDelete(Entity entity);
        Task<int> SaveChangesAsync();
        DbSet<Entity> Table { get; }
    }
}
