using BelugaAPI.Provider.Providers.Results;

namespace BelugaAPI.Provider.Providers.Interfaces;

public interface IAssistantService
{
    
    Task<ThreadResult> CreateThread();
    Task AddMessage(string threadId, string message);
    Task<RunResult> CreateRun(string threadId, string assistantId);
    Task<RunResult> CreateThreadAndRun(string assistantId, string message);
    
    // Task<object> GetThread(string threadId);
    // Task<object> RetrieveAssistant(string assistantId);
}