using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AuditLogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AuditLog>> GetAllAsync()
        {
            return await _dbContext.AuditLogs
                .OrderByDescending(x => x.AuditLogId)
                .ToListAsync();
        }

        public async Task<AuditLog?> GetByIdAsync(int id)
        {
            return await _dbContext.AuditLogs.FindAsync(id);
        }

        public async Task AddAsync(AuditLog auditLog)
        {
            await _dbContext.AuditLogs.AddAsync(auditLog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AuditLog auditLog)
        {
            _dbContext.AuditLogs.Update(auditLog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var auditLog = await _dbContext.AuditLogs.FindAsync(id);

            if (auditLog == null)
                return;

            _dbContext.AuditLogs.Remove(auditLog);
            await _dbContext.SaveChangesAsync();
        }
    }
}
