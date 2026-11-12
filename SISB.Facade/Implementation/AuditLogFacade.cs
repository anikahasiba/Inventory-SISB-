using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class AuditLogFacade : IAuditLogFacade
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogFacade(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        public async Task<List<AuditLog>> GetAuditLogsAsync()
        {
            return await _auditLogRepository.GetAllAsync();
        }

        public async Task<AuditLog?> GetAuditLogByIdAsync(int id)
        {
            return await _auditLogRepository.GetByIdAsync(id);
        }

        public async Task AddAuditLogAsync(AuditLog auditLog)
        {
            ArgumentNullException.ThrowIfNull(auditLog);
            await _auditLogRepository.AddAsync(auditLog);
        }

        public async Task<bool> UpdateAuditLogAsync(AuditLog auditLog)
        {
            ArgumentNullException.ThrowIfNull(auditLog);

            var existing = await _auditLogRepository.GetByIdAsync(auditLog.AuditLogId);
            if (existing == null)
                return false;

            await _auditLogRepository.UpdateAsync(auditLog);
            return true;
        }

        public async Task<bool> DeleteAuditLogAsync(int id)
        {
            var existing = await _auditLogRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _auditLogRepository.DeleteAsync(id);
            return true;
        }
    }
}
