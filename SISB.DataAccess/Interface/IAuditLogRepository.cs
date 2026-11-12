using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IAuditLogRepository
    {
        Task<List<AuditLog>> GetAllAsync();
        Task<AuditLog?> GetByIdAsync(int id);
        Task AddAsync(AuditLog auditLog);
        Task UpdateAsync(AuditLog auditLog);
        Task DeleteAsync(int id);
    }
}
