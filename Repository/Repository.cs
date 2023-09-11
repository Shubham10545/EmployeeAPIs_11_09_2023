using Domain;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BasicEntity
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<T> _entities;
        public Repository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        public async Task<T> Get(int id)
        {
                return await _entities.FindAsync(id);   
        }

        public async Task<bool> Update(T entity)
        {
            _entities.Update(entity);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        async Task<bool> IRepository<T>.Insert(T entity)
        {
            await _entities.AddAsync(entity);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

        async Task<bool> IRepository<T>.Delete(T entity)
        {
            _entities.Remove(entity);
            return await _appDbContext.SaveChangesAsync() > 0;
        }

       

    }
}