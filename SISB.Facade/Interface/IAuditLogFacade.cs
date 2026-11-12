using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IAuditLogFacade
    {
        Task<List<AuditLog>> GetAuditLogsAsync();
        Task<AuditLog?> GetAuditLogByIdAsync(int id);
        Task AddAuditLogAsync(AuditLog auditLog);
        Task<bool> UpdateAuditLogAsync(AuditLog auditLog);
        Task<bool> DeleteAuditLogAsync(int id);
    }
}
