using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IForecastResultRepository
    {
        Task<List<ForecastResult>> GetAllAsync();
        Task<ForecastResult?> GetByIdAsync(int id);
        Task AddAsync(ForecastResult forecastResult);
        Task UpdateAsync(ForecastResult forecastResult);
        Task DeleteAsync(int id);
    }
}
