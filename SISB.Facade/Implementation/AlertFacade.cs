using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class AlertFacade : IAlertFacade
    {
        private readonly IAlertRepository _alertRepository;

        public AlertFacade(IAlertRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public async Task<List<Alert>> GetAlertsAsync()
        {
            return await _alertRepository.GetAllAsync();
        }

        public async Task<Alert?> GetAlertByIdAsync(int id)
        {
            return await _alertRepository.GetByIdAsync(id);
        }

        public async Task AddAlertAsync(Alert alert)
        {
            ArgumentNullException.ThrowIfNull(alert);
            await _alertRepository.AddAsync(alert);
        }

        public async Task<bool> UpdateAlertAsync(Alert alert)
        {
            ArgumentNullException.ThrowIfNull(alert);

            var existing = await _alertRepository.GetByIdAsync(alert.AlertId);
            if (existing == null)
                return false;

            await _alertRepository.UpdateAsync(alert);
            return true;
        }

        public async Task<bool> DeleteAlertAsync(int id)
        {
            var existing = await _alertRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _alertRepository.DeleteAsync(id);
            return true;
        }
    }
}
