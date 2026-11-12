using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IAiChatLogRepository
    {
        Task<List<AiChatLog>> GetAllAsync();
        Task<AiChatLog?> GetByIdAsync(int id);
        Task AddAsync(AiChatLog aiChatLog);
        Task UpdateAsync(AiChatLog aiChatLog);
        Task DeleteAsync(int id);
    }
}
