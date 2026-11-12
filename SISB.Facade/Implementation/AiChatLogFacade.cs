using SISB.DataAccess.Interface;
using SISB.Entities;
using SISB.Facade.Interface;

namespace SISB.Facade.Implementation
{
    public class AiChatLogFacade : IAiChatLogFacade
    {
        private readonly IAiChatLogRepository _aiChatLogRepository;

        public AiChatLogFacade(IAiChatLogRepository aiChatLogRepository)
        {
            _aiChatLogRepository = aiChatLogRepository;
        }

        public async Task<List<AiChatLog>> GetAiChatLogsAsync()
        {
            return await _aiChatLogRepository.GetAllAsync();
        }

        public async Task<AiChatLog?> GetAiChatLogByIdAsync(int id)
        {
            return await _aiChatLogRepository.GetByIdAsync(id);
        }

        public async Task AddAiChatLogAsync(AiChatLog aiChatLog)
        {
            ArgumentNullException.ThrowIfNull(aiChatLog);
            await _aiChatLogRepository.AddAsync(aiChatLog);
        }

        public async Task<bool> UpdateAiChatLogAsync(AiChatLog aiChatLog)
        {
            ArgumentNullException.ThrowIfNull(aiChatLog);

            var existing = await _aiChatLogRepository.GetByIdAsync(aiChatLog.AiChatLogId);
            if (existing == null)
                return false;

            await _aiChatLogRepository.UpdateAsync(aiChatLog);
            return true;
        }

        public async Task<bool> DeleteAiChatLogAsync(int id)
        {
            var existing = await _aiChatLogRepository.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _aiChatLogRepository.DeleteAsync(id);
            return true;
        }
    }
}
