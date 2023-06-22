using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_Commerce.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }
        //Get All List
        public async Task<IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();
       //  public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties) => await _context.Set<T>().ToListAsync();

        // public async Task<IEnumerable<T>> GetAll(System.Func<object, object> value) => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        //Get Single Record By Id
        public async Task<T> GetById(int id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        //Add new Record in Database
        public async Task AddAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();

        }


        //Delete Record From Database
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(result);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();


            //_context.Set<T>().Remove(result);
            //await _context.SaveChangesAsync();

        }

        //Update Record in Database
        public async Task<T> UpdateAsync(int id, T Entity)
        {
            // _context.Update(Entity);
            // _context.Set<T>().Update(Entity);
           // await _context.SaveChangesAsync();

            EntityEntry entityEntry =   _context.Entry<T>(Entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Entity;
        }

        //public async Task<IEnumerable<T>> GetAll()
        //{
        //    var result = await _context.Set<T>().ToListAsync();
        //    return result;
        //}


        //public async Task<T> GetById(int id) 
        //{
        //  //  var data = await _context.Set<T>().FindAsync(id);
        //    var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        //    return result;
        //}









    }
}
