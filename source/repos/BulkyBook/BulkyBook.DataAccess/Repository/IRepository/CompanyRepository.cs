﻿using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    { 
        private readonly ApplicationDbContext _db;
        
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Company obj)
        {
            //throw new NotImplementedException();
            _db.Companies.Update(obj);
        }

        //IEnumerable<Category> IRepository<CoverType>.GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

