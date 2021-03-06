﻿using Microsoft.EntityFrameworkCore;
using Project.Domain.Contracts.Repositories.Common;
using Project.Repository.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Repository.Repositories.Common
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> 
        where TEntity : class
    {
        protected readonly AppDbContext db;

        public RepositoryBase()
        {
            db = new AppDbContext();
        }

        public virtual async Task AddAsync(TEntity obj)
        {
            db.Add(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int? id)
        {
            return await db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task RemoveAsync(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> SearchByNameOrColor(string searchObj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
