using Microsoft.AspNetCore.Mvc;
using ShiftsLogger.API.Models;
using ShiftsLogger.API.Models.DTOs;
using ShiftsLogger.API.Services;

namespace ShiftsLogger.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class WorkerController : ControllerBase
{
    private readonly IWorkerService _workerService;
    public WorkerController(IWorkerService workerService)
    {
        _workerService = workerService;
    }

    [HttpPost]
    public async Task<ActionResult<Worker>> AddWorker(WorkerDto workerDto)
    {
        Worker worker = new()
        {
            Name = workerDto.Name,
        }; 

        await _workerService.AddWorkerAsync(worker);
        return CreatedAtAction(nameof(GetWorkerById), new {id = worker.Id} ,worker);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Worker>> GetWorkerById(int id)
    {
        var worker = await _workerService.GetWorkerByIdAsync(id);
        if (worker is null)
        { 
            return NotFound();
        }

        return Ok(worker);
    }

    [HttpGet]
    public async Task<ActionResult<List<Worker>>> GetAllWorkers()
    {
        return Ok(await _workerService.GetAllWorkersAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Worker>> UpdateWorker(int id, WorkerDto workerDto)
    {
        Worker worker = await _workerService.GetWorkerByIdAsync(id);
        if (worker is null)
        {
            return NotFound();
        }

        worker.Name = workerDto.Name;
        await _workerService.UpdateWorkerAsync(id, worker);
        return Ok(worker);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteWorker(int id)
    {
        bool isWorkerDeleted = await _workerService.DeleteWorkerAsync(id);

        if (isWorkerDeleted)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }


}
