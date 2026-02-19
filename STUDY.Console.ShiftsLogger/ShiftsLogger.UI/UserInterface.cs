using ShiftsLogger.UI.Controller;
using ShiftsLogger.UI.DTOs;
using ShiftsLogger.UI.Services;
using Spectre.Console;

namespace ShiftsLogger.UI;

public class UserInterface
{
    private readonly WorkerController _workerController = new();
    private readonly ShiftService _shiftService = new();

    public async Task Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            AnsiConsole.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]Shifts Logger - Main Menu[/]")
                    .AddChoices(new[] {
                        "View All Workers",
                        "Add a New Worker",
                        "Exit"
                    }));

            switch (choice)
            {
                case "View All Workers":
                    var worker = await _workerController.GetAllWorkers();
                    if (worker is not null)
                        await ManageWorker(worker);
                    break;
                case "Add a New Worker":
                    await _workerController.AddWorker();
                    break;
                case "Exit":
                    isRunning = false;
                    break;
            }
            
            if (choice != "Exit")
            {
                AnsiConsole.MarkupLine("\nPress any key to continue...");
                Console.ReadKey(true);
                AnsiConsole.Clear();
            }
        }
    }

    private async Task ManageWorker(WorkerDto worker)
    {
        bool inWorkerMenu = true;
        while (inWorkerMenu)
        {
            AnsiConsole.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Worker Management for: [cyan]{worker.Name}[/]")
                    .AddChoices(new[] {
                        "Update Worker Data",
                        "Delete Worker",
                        "Manage Worker Shifts",
                        "Back to Main Menu"
                    }));
    
            switch (choice)
            {
                case "Update Worker Data":
                    var newName = await _workerController.UpdateWorker(worker);
                    if (newName is not null)
                        worker.Name = newName;
                    break;
                case "Delete Worker":
                    inWorkerMenu = !await _workerController.DeleteWorker(worker);
                    break;
                case "Manage Worker Shifts":
                    await _workerController.ManageWorkerShifts(worker);
                    break;
                case "Back to Main Menu":
                    inWorkerMenu = false;
                    break;
            }
    
            if (choice != "Back to Main Menu")
            {
                AnsiConsole.MarkupLine("\nPress any key to continue...");
                Console.ReadKey(true);
            }
        }
    }
}