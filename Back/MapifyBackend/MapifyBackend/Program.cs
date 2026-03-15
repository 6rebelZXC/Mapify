using System.Text.Json;
using MapifyBackend;
using MapifyBackend.database_files;
using Microsoft.EntityFrameworkCore.Storage;

DatabaseInitializer.EnsureDatabaseCreated();

var dbService = new DatabaseService();
var stratService = new StratService(dbService);
// stratService.CreateStrat("cool ash rush", "youtube.com", "Oregon");
Console.WriteLine(dbService.GetAllStrats());
Console.WriteLine(dbService.GetStrat(1));
Console.WriteLine(JsonSerializer.Serialize(dbService.GetAllStrats(), new JsonSerializerOptions
{
    WriteIndented = true
}));

Console.WriteLine(JsonSerializer.Serialize(dbService.GetStrat(1), new JsonSerializerOptions
{
    WriteIndented = true
}));


