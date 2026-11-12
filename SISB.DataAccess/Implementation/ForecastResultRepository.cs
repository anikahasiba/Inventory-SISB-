using SISB.DataAccess.Interface;
using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SISB.DataAccess.Implementation
{
    public class ForecastResultRepository : IForecastResultRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ForecastResultRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ForecastResult>> GetAllAsync()
        {
            return await _dbContext.ForecastResults
                .OrderByDescending(x => x.ForecastResultId)
                .ToListAsync();
        }

        public async Task<ForecastResult?> GetByIdAsync(int id)
        {
            return await _dbContext.ForecastResults.FindAsync(id);
        }

        public async Task AddAsync(ForecastResult forecastResult)
        {
            await _dbContext.ForecastResults.AddAsync(forecastResult);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ForecastResult forecastResult)
        {
            _dbContext.ForecastResults.Update(forecastResult);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var forecastResult = await _dbContext.ForecastResults.FindAsync(id);

            if (forecastResult == null)
                return;

            _dbContext.ForecastResults.Remove(forecastResult);
            await _dbContext.SaveChangesAsync();
        }
    }
}
