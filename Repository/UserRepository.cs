using animeAppWebApi.Data;
using animeAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animeAppWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext context;

        public UserRepository(UserDBContext userContext)
        {
            context = userContext;
        }

        ////listing all users
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            try
            {
                var users = await context.userModels.ToListAsync();
                return users.AsQueryable();
            }
            catch
            {
                throw;
            }
        }       
        //user signup
        public async Task SignUpUser(UserModel user)
        {
            try
            {
                context.userModels.Add(user);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        //user delete
        public async Task DeleteUser(int id)
        {
            try
            {
                UserModel user = await context.userModels.FindAsync(id);
                context.userModels.Remove(user);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserModel> LoginUser(UserModel user)
        {
            try
            {
                UserModel userdb = await context.userModels.SingleOrDefaultAsync(u => u.username.Equals(user.username));
                if (userdb == null || user.userPassword != userdb.userPassword)
                    return null;
                return userdb;
            }
            catch
            {
                throw;
            }
        }


    }
}
