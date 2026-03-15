namespace MapifyBackend.database_files;

public class StratService
{
    public DatabaseService DbService;

    public StratService(DatabaseService databaseService)
    {
        DbService = databaseService;
    }
    
    public void CreateStrat(string name, string videoUrl, string mapName)
    {
        int mapId = DbService.GetMapIdByName(mapName);

        Strat strat = new Strat(name, videoUrl, mapId);
        DbService.AddStrat(strat);
    }
}