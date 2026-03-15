using MapifyBackend;
using MapifyBackend.database_files;
using Microsoft.EntityFrameworkCore.Storage;

DatabaseInitializer.EnsureDatabaseCreated();

var dbService = new DatabaseService();
var stratService = new StratService(dbService);
stratService.CreateStrat("cool ash rush", "youtube.com", "Oregon");