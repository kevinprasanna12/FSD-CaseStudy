﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly EventDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(EventDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();
        public T Get(object id) => _dbSet.Find(id);
        public void Add(T entity) 
        { _dbSet.Add(entity); 
            _context.SaveChanges();
        }

        public void Update(T entity) 
        { _dbSet.Update(entity);
            _context.SaveChanges(); 
        }
        public void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }

}
