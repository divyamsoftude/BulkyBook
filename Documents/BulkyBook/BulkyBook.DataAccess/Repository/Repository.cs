using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db= db;
            //_db.Products.Include(u => u.Category);
            this.dbSet= _db.Set<T>();
        }

        public void Add(T entity)
        {
            //throw new NotImplementedException();
            dbSet.Add(entity);
        }
        //includeProp - "Category,Covertype"
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            { 
                query = query.Where(filter);
            }
            if (includeProperties != null) 
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);

                }
            }
            return query.ToList();
            //throw new NotImplementedException();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter=null, string? includeProperties = null, bool tracked = true)
        {
            //throw new NotImplementedException();
            IQueryable<T> query;

            if (tracked)
            {
                query = dbSet;
            }
            else 
            {
                query = dbSet.AsNoTracking();
            }

            query=query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);

                }
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            //throw new NotImplementedException();
            dbSet.Remove(entity); 
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            //throw new NotImplementedException();
            dbSet.RemoveRange(entity);
        }
    }
}
