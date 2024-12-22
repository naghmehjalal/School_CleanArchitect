using Core.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> ExistAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        //----------------------------------------------
        T Get(int id);
        void  Update(T entity);
        public T Add(T entity);
        public void Delete(T entity);
        public bool Exist(int id);
        public IReadOnlyList<T> GetAll();

    }
}
