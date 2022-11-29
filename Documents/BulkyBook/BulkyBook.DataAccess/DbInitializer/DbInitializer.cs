using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BulkyBook.Utility;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }



        public void Initialize()
        {
            // migrations if they are not applied.
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0) 
                {
                    _db.Database.Migrate();
                }
            }

            catch (Exception ex)
            {

            }

            // create roles if they are not created.

            if (!_roleManager.RoleExistsAsync(SD.Role_usr_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_usr_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_usr_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_usr_Indi)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_usr_Comp)).GetAwaiter().GetResult();

                // if roles are not created, then we will create admin user as well.

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Admin4@gmail.com",
                    Email = "Admin4@gmail.com",
                    Name = "Admin 4",
                    PhoneNumber = "9425910190",
                    StreetAddress = "New York St 2",
                    State = "Washington",
                    PostalCode = "501958",
                    City = "New York",

                }, "Admin@1234").GetAwaiter().GetResult();

                ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "Admin4@gmail.com");

                _userManager.AddToRoleAsync(user, SD.Role_usr_Admin).GetAwaiter().GetResult();
            }
            return;

        }

    }
}
