using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class AlertRepository : IAlertRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AlertRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Alert>> GetAllAsync()
        {
            return await _dbContext.Alerts
                .OrderByDescending(x => x.AlertId)
                .ToListAsync();
        }

        public async Task<Alert?> GetByIdAsync(int id)
        {
            return await _dbContext.Alerts.FindAsync(id);
        }

        public async Task AddAsync(Alert alert)
        {
            await _dbContext.Alerts.AddAsync(alert);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Alert alert)
        {
            _dbContext.Alerts.Update(alert);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var alert = await _dbContext.Alerts.FindAsync(id);

            if (alert == null)
                return;

            _dbContext.Alerts.Remove(alert);
            await _dbContext.SaveChangesAsync();
        }
    }
}
