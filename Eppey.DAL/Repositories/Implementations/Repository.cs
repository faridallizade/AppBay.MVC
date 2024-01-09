using Eppey.CORE.Entities.Base;
using Eppey.DAL.Context;
using Eppey.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eppey.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseAudiTableEntity, new()
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public bool Check(int id)
        {
            if (Table.Any(x => x.Id == id && x.IsDeleted == false)) return true;
            return false;
        }

        public async Task Create(T entity)
        {
            await Table.AddAsync(entity);
        }


        public void delete(int id)
        {
            if(Table.Any(x=>x.Id == id && x.IsDeleted == false))
            {
                var entity = Table.FirstOrDefault(x => x.Id == id);
                if(entity != null)
                {
                    entity.IsDeleted = true;
                }
                SaveChanges();
            }
            throw new Exception("Not found");
        }


        public async Task<T> GetById(int id)
        {
            if (Check(id))
            {
                return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            throw new Exception("Not found");
        }


        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = Table.Where(b => !b.IsDeleted);
            if(includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if(expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}
