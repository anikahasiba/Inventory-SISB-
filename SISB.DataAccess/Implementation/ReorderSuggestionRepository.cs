using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class ReorderSuggestionRepository : IReorderSuggestionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReorderSuggestionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ReorderSuggestion>> GetAllAsync()
        {
            return await _dbContext.ReorderSuggestions
                .OrderByDescending(x => x.ReorderSuggestionId)
                .ToListAsync();
        }

        public async Task<ReorderSuggestion?> GetByIdAsync(int id)
        {
            return await _dbContext.ReorderSuggestions.FindAsync(id);
        }

        public async Task AddAsync(ReorderSuggestion reorderSuggestion)
        {
            await _dbContext.ReorderSuggestions.AddAsync(reorderSuggestion);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ReorderSuggestion reorderSuggestion)
        {
            _dbContext.ReorderSuggestions.Update(reorderSuggestion);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reorderSuggestion = await _dbContext.ReorderSuggestions.FindAsync(id);

            if (reorderSuggestion == null)
                return;

            _dbContext.ReorderSuggestions.Remove(reorderSuggestion);
            await _dbContext.SaveChangesAsync();
        }
    }
}
