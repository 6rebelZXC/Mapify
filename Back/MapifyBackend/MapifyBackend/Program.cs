using MapifyBackend;
using MapifyBackend.database_files;
using Microsoft.EntityFrameworkCore.Storage;

DatabaseInitializer.EnsureDatabaseCreated();

var dbService = new DatabaseService();
Strat coolAshRush = new Strat("ashRush", "sussybaka");
dbService.AddStrat(coolAshRush);