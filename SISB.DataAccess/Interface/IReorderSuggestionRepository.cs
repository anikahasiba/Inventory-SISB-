using SISB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISB.DataAccess.Interface
{
    public interface IReorderSuggestionRepository
    {
        Task<List<ReorderSuggestion>> GetAllAsync();
        Task<ReorderSuggestion?> GetByIdAsync(int id);
        Task AddAsync(ReorderSuggestion reorderSuggestion);
        Task UpdateAsync(ReorderSuggestion reorderSuggestion);
        Task DeleteAsync(int id);
    }
}
