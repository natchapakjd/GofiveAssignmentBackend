﻿using AssignmentAPI.Data;
using AssignmentAPI.Models.Domain;
using AssignmentAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssignmentAPI.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext dbContext;

        public UserRepository(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(string id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(c => c.id == id);
            if (existingUser is null)
            {
                return null;
            }

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<IEnumerable<User>> GetDataTable(string? query = null, string? sortBy = null, string? sortDirection = null,int? pageNumber = 1, int? pageSize = 100)
        {
            //return await dbContext.Users.ToListAsync();
            //Query 
            var users = dbContext.Users.AsQueryable();

            //Filtering
            if(string.IsNullOrWhiteSpace(query) == false)
            {
                users =  users.Where(u => u.firstName.Contains(query));
            }
            //Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (string.Equals(sortBy, "firstName", StringComparison.OrdinalIgnoreCase))
                {
                    var isAsc =string.Equals(sortDirection,"asc",StringComparison.OrdinalIgnoreCase)? true : false;

                    users = isAsc ?  users.OrderBy(x => x.firstName) : users.OrderByDescending(x => x.firstName);
                }
            }
            //Pagination

            var skipResults = (pageNumber - 1) * pageSize;
            users = users.Skip(skipResults ?? 0 ).Take(pageSize ?? 100);
            return await users.ToListAsync();


        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
            

        }
        public async Task<User?> GetById(string id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(c => c.id == id);
        }

        public async  Task<User?> UpdateAsync(User user)
        {
            var existingUser = await dbContext.Users.Include(c=>c.Permissions).FirstOrDefaultAsync(c => c.id == user.id);
            if (existingUser != null)
            {
                dbContext.Entry(existingUser).CurrentValues.SetValues(user);
                await dbContext.SaveChangesAsync();
                return user;
            }

            return null;
        }
    }
}
