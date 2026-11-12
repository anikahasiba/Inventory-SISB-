using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class ForecastResultFacade : IForecastResultFacade
    {
        private readonly IForecastResultRepository _forecastResultRepository;

        public ForecastResultFacade(IForecastResultRepository forecastResultRepository)
        {
            _forecastResultRepository = forecastResultRepository;
        }

        public async Task<List<ForecastResult>> GetForecastResultsAsync()
        {
            return await _forecastResultRepository.GetAllAsync();
        }

        public async Task<ForecastResult?> GetForecastResultByIdAsync(int id)
        {
            return await _forecastResultRepository.GetByIdAsync(id);
        }

        public async Task AddForecastResultAsync(ForecastResult forecastResult)
        {
            ArgumentNullException.ThrowIfNull(forecastResult);
            await _forecastResultRepository.AddAsync(forecastResult);
        }

        public async Task<bool> UpdateForecastResultAsync(ForecastResult forecastResult)
        {
            ArgumentNullException.ThrowIfNull(forecastResult);

            var existing = await _forecastResultRepository.GetByIdAsync(forecastResult.ForecastResultId);
            if (existing == null)
                return false;

            await _forecastResultRepository.UpdateAsync(forecastResult);
            return true;
        }

        public async Task<bool> DeleteForecastResultAsync(int id)
        {
            var existing = await _forecastResultRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _forecastResultRepository.DeleteAsync(id);
            return true;
        }
    }
}
