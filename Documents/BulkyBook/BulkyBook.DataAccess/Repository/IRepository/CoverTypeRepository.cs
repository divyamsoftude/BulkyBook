using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, /*IRepository.*/ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;
        
        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Category GetFirstOrDefault(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Category> entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            
            _db.SaveChanges();
        }

        public void Update(CoverType obj)
        {
            //throw new NotImplementedException();
            _db.CoverType.Update(obj);
        }

        public void Update(Category obj)
        {
            throw new NotImplementedException();
        }

        //IEnumerable<Category> IRepository<CoverType>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
