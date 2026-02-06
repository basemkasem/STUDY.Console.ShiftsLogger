using ShiftsLogger.UI.DTOs;
using ShiftsLogger.UI.Services;
using Spectre.Console;

namespace ShiftsLogger.UI.Controller;

public class WorkerController
{
    private readonly WorkerService _workerService = new();

    public async Task AddWorker()
    {
        var name = AnsiConsole.Ask<string>("Enter worker name: ");

        try
        {
            await _workerService.AddWorker(name);
            AnsiConsole.MarkupLine("[green]Worker added successfully![/]");
        }
        catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[red]{e.Message}[/]");
        }
    }

    public async Task GetAllWorkers()
    {
        try
        {
            var workers = await _workerService.GetAllWorkers();
            if (workers is null)
            {
                AnsiConsole.MarkupLine("[red]No workers found![/]");
                return;
            }

            var workerChoice = AnsiConsole.Prompt<WorkerDto>(
                new SelectionPrompt<WorkerDto>()
                    .Title("Select A Worker to View Shifts:")
                    .AddChoices(workers)
                    .UseConverter(w => w.Name)
            );
        }
        catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[red]{e.Message}[/]");
        }
    }
}