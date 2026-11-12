using SISB.Entities;

namespace SISB.Facade.Interface
{
    public interface IAiChatLogFacade
    {
        Task<List<AiChatLog>> GetAiChatLogsAsync();
        Task<AiChatLog?> GetAiChatLogByIdAsync(int id);
        Task AddAiChatLogAsync(AiChatLog aiChatLog);
        Task<bool> UpdateAiChatLogAsync(AiChatLog aiChatLog);
        Task<bool> DeleteAiChatLogAsync(int id);
    }
}
