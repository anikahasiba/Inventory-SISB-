using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return await _dbContext.Users
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task AddAsync(ApplicationUser applicationUser)
        {
            await _dbContext.Users.AddAsync(applicationUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ApplicationUser applicationUser)
        {
            _dbContext.Users.Update(applicationUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var applicationUser = await _dbContext.Users.FindAsync(id);

            if (applicationUser == null)
                return;

            _dbContext.Users.Remove(applicationUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
