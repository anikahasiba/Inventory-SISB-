using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class AiChatLogRepository : IAiChatLogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AiChatLogRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AiChatLog>> GetAllAsync()
        {
            return await _dbContext.AiChatLogs
                .OrderByDescending(x => x.AiChatLogId)
                .ToListAsync();
        }

        public async Task<AiChatLog?> GetByIdAsync(int id)
        {
            return await _dbContext.AiChatLogs.FindAsync(id);
        }

        public async Task AddAsync(AiChatLog aiChatLog)
        {
            await _dbContext.AiChatLogs.AddAsync(aiChatLog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(AiChatLog aiChatLog)
        {
            _dbContext.AiChatLogs.Update(aiChatLog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aiChatLog = await _dbContext.AiChatLogs.FindAsync(id);

            if (aiChatLog == null)
                return;

            _dbContext.AiChatLogs.Remove(aiChatLog);
            await _dbContext.SaveChangesAsync();
        }
    }
}
