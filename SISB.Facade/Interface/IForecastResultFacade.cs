using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IForecastResultFacade
    {
        Task<List<ForecastResult>> GetForecastResultsAsync();
        Task<ForecastResult?> GetForecastResultByIdAsync(int id);
        Task AddForecastResultAsync(ForecastResult forecastResult);
        Task<bool> UpdateForecastResultAsync(ForecastResult forecastResult);
        Task<bool> DeleteForecastResultAsync(int id);
    }
}
