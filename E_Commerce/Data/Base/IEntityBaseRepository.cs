using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace E_Commerce.Data.Base
{
    public interface IEntityBaseRepository <T> where T : class , IEntityBase, new()
    {
        // public Task<IEnumerable<T>> GetAll(System.Func<object, object> value);
        
        public Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        public Task<T> GetById(int id);
        public Task AddAsync(T Entity);
        public Task DeleteAsync(int id);
        public Task<T> UpdateAsync(int id, T Entity);



    }
}
