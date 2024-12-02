using System.Net.Http.Headers;
using System.Text.Json;
using BelugaAPI.Provider.Providers.Interfaces;
using BelugaAPI.Provider.Providers.Results;
using Microsoft.Extensions.Configuration;

namespace BelugaAPI.Provider.Providers;

public class OpenAiService : IAssistantService
{
    private readonly string _openAiApiUrl = "https://api.openai.com";
    private readonly HttpClient _httpClient;
    
    public OpenAiService(IConfiguration configuration)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            configuration.GetConnectionString("OpenAi")
        );
        _httpClient.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v2");
    }

    public async Task<ThreadResult> CreateThread()
    {
        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_openAiApiUrl}/v1/threads");

            var response = await _httpClient.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao chamar a API de Assistente: {response.ReasonPhrase}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            
            var objResponse = JsonSerializer.Deserialize<ThreadResult>(responseContent);
            
            if (objResponse == null)
            {
                throw new Exception($"Erro ao chamar a API de Assistente: {response.ReasonPhrase}");
            }

            return objResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task AddMessage(string threadId, string message)
    {
        try
        {
            var jsonObject = new
            {
                role = "user",
                content = message
            };

            var jsonBody = JsonSerializer.Serialize(jsonObject);

            var content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync(
                $"{_openAiApiUrl}/v1/threads/{threadId}/messages", 
                content
                );
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao chamar a API de Assistente: {response.ReasonPhrase}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<RunResult> CreateRun(string threadId, string assistantId)
    {
        try
        {
            var jsonObject = new
            {
                assistant_id = assistantId,
            };
            
            var jsonBody = JsonSerializer.Serialize(jsonObject);

            var content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
            
            var response = await _httpClient.PostAsync($"{_openAiApiUrl}/v1/threads/{threadId}/runs", content);
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao chamar a API de Assistente: {response.ReasonPhrase}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            
            var objResponse = JsonSerializer.Deserialize<RunResult>(responseContent);
            
            if (objResponse == null)
            {
                throw new Exception($"Erro ao chamar a API de Assistente: {response.ReasonPhrase}");
            }

            return objResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<RunResult> CreateThreadAndRun(string assistantId, string message)
    {
        try
        {
            // using var request = new HttpRequestMessage(HttpMethod.Get, $"{_openAiApiUrl}/v1/threads/{threadId}");
            // request.Headers.Add("OpenAI-Beta", "assistants=v2"); // Cabeçalho específico para essa requisição
            //
            //
            var jsonObject = new
            {
                assistant_id = assistantId,
                thread = new
                {
                    messages = new []{
                        new
                        {
                            role = "user",
                            content = message
                        }
                    }
                }
            };
            
            var jsonBody = JsonSerializer.Serialize(jsonObject);

            var content = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");
            
            
            var response = await _httpClient.PostAsync($"{_openAiApiUrl}/v1/threads/runs", content);
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao chamar a API de Assistente: {response.ReasonPhrase}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Desserializa o JSON para o tipo AssistantResult
            var objResponse = JsonSerializer.Deserialize<RunResult>(responseContent);
            
            if (objResponse == null)
            {
                throw new Exception($"Erro ao chamar a API de Assistente: {response.ReasonPhrase}");
            }

            return objResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }  
}