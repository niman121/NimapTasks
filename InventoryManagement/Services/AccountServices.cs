using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using InventoryManagement.Models;
using InventoryManagement.ViewModels;

namespace InventoryManagement.Services
{
    public class AccountServices
    { 
        private static readonly InventoryDbContext _context = new InventoryDbContext();
        
        public async Task RegisterUserToDbAsync(RegisterViewModel model)
        {
            var user = new User();
            user.Email = model.Email;
            user.Name = model.UserName;
            user.Password = model.Password;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> ValidateUserAsync(LoginViewModel model)
        {
            var userFromDb = await _context.Users.SingleOrDefaultAsync(q =>
                    q.Name == model.UserName && q.Password == model.Password);
            if (userFromDb != null) return true;
            return false;
        }

        public async Task<List<Role>> GetUserRolesFromDb(string userName)
        {
            var roles = new List<Role>();
            var usersWithRoles = await _context.Users.Include(q => q.Roles).Where(q => q.Name == userName)
                .FirstOrDefaultAsync();
            foreach (var role in usersWithRoles.Roles)
            {
                roles.Add(role);
            }
            return roles;
        }


    }
}