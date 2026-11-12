using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class ReorderSuggestionFacade : IReorderSuggestionFacade
    {
        private readonly IReorderSuggestionRepository _reorderSuggestionRepository;

        public ReorderSuggestionFacade(IReorderSuggestionRepository reorderSuggestionRepository)
        {
            _reorderSuggestionRepository = reorderSuggestionRepository;
        }

        public async Task<List<ReorderSuggestion>> GetReorderSuggestionsAsync()
        {
            return await _reorderSuggestionRepository.GetAllAsync();
        }

        public async Task<ReorderSuggestion?> GetReorderSuggestionByIdAsync(int id)
        {
            return await _reorderSuggestionRepository.GetByIdAsync(id);
        }

        public async Task AddReorderSuggestionAsync(ReorderSuggestion reorderSuggestion)
        {
            ArgumentNullException.ThrowIfNull(reorderSuggestion);
            await _reorderSuggestionRepository.AddAsync(reorderSuggestion);
        }

        public async Task<bool> UpdateReorderSuggestionAsync(ReorderSuggestion reorderSuggestion)
        {
            ArgumentNullException.ThrowIfNull(reorderSuggestion);

            var existing = await _reorderSuggestionRepository.GetByIdAsync(reorderSuggestion.ReorderSuggestionId);
            if (existing == null)
                return false;

            await _reorderSuggestionRepository.UpdateAsync(reorderSuggestion);
            return true;
        }

        public async Task<bool> DeleteReorderSuggestionAsync(int id)
        {
            var existing = await _reorderSuggestionRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _reorderSuggestionRepository.DeleteAsync(id);
            return true;
        }
    }
}
