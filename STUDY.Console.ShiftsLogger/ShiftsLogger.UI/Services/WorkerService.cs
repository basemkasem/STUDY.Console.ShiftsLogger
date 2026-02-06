using System.Net.Http.Json;
using ShiftsLogger.UI.DTOs;

namespace ShiftsLogger.UI.Services;

public class WorkerService
{
    private readonly HttpClient _httpClient = new();

    public async Task<List<WorkerDto>?> GetAllWorkers()
    {
        var response = await _httpClient.GetFromJsonAsync<List<WorkerDto>>("http://localhost:5298/api/Worker");
        return response;
    }
    public async Task AddWorker(string name)
    { 
        await _httpClient.PostAsJsonAsync("http://localhost:5298/api/Worker", new { Name = name });
    }
    
    public bool DeleteWorker()
    {
        return false;
    }
    public bool UpdateWorker()
    {
        return false;
    }
    public void GetWorkerDetails()
    {
        
    }
}