using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IReorderSuggestionFacade
    {
        Task<List<ReorderSuggestion>> GetReorderSuggestionsAsync();
        Task<ReorderSuggestion?> GetReorderSuggestionByIdAsync(int id);
        Task AddReorderSuggestionAsync(ReorderSuggestion reorderSuggestion);
        Task<bool> UpdateReorderSuggestionAsync(ReorderSuggestion reorderSuggestion);
        Task<bool> DeleteReorderSuggestionAsync(int id);
    }
}
