using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IAlertFacade
    {
        Task<List<Alert>> GetAlertsAsync();
        Task<Alert?> GetAlertByIdAsync(int id);
        Task AddAlertAsync(Alert alert);
        Task<bool> UpdateAlertAsync(Alert alert);
        Task<bool> DeleteAlertAsync(int id);
    }
}
