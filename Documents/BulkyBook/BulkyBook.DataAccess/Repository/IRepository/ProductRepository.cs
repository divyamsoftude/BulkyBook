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
    public class ProductRepository : Repository<Product>, /*IRepository.*/IProductRepository 
    {
        private ApplicationDbContext _db;
        
        public ProductRepository(ApplicationDbContext db) : base(db)
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

        public void Update(Product obj)
        {
            //throw new NotImplementedException();
            //_db.Products.Update(obj);
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null) 
            {
                objFromDb.Title= obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.Author = obj.Author;
                objFromDb.CoverTypeId = obj.CoverTypeId;

                if (obj.ImageUrl != null) 
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }

        //public void Update(Category obj)
        //{
        //    throw new NotImplementedException();
        //}

        //IEnumerable<Category> IRepository<CoverType>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
