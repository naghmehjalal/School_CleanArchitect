using Azure.Core;
using Core.Application.Contracts.Persistence;
using Core.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppContext _context;

        public GenericRepository(AppContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<T> GetAsync(int id)
        {
            var obj =await _context.Set<T>().FindAsync(id);
           
            if (obj == null)
                throw new NotFoundException(nameof(T),id);

            return obj;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var list=await _context.Set<T>().ToListAsync();
            if (list == null)
                throw new NotFoundException(nameof(T));

            return list;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //-----------------------------------------------------
        public T Get(int id)
        {
            var obj =  _context.Set<T>().Find(id);

            if (obj == null)
                throw new NotFoundException(nameof(T), id);

            return obj;
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public  T Add(T entity)
        {
             _context.AddAsync(entity);
             _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
        }

        public bool Exist(int id)
        {
            var entity = Get(id);
            return entity != null;
        }

        public IReadOnlyList<T> GetAll()
        {
            var list =  _context.Set<T>().ToList();
            if (list == null)
                throw new NotFoundException(nameof(T));

            return list;
        }
    }
}
