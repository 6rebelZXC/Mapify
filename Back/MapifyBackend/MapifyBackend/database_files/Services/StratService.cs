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

    //returns a result of GetStrat(int id) method from DatabaseService
    public Strat? GetStratId(int id)
    {
        return DbService.GetStrat(id);
    }

    //returns a result of GetAllStrats() method from DatabaseService
    public List<Strat> GetAllStrats()
    {
        return DbService.GetAllStrats();
    }

    //validates if there is a strat by given ID, returns false if there is none, or calls DeleteStrat from DBService 
    public bool DeleteStrat(int id)
    {
        var strat = GetStratId(id);
        if (strat == null) return false;

        DbService.DeleteStrat(id);
        return true;
    }

    public void AssignStratToCategory(int stratId, int categoryId)
    {
        DbService.AssignStratToCategory(stratId, categoryId);
    }

    public List<Strat>? GetStratsByCategory(int categoryId)
    {
        return DbService.GetStratsByCategory(categoryId);
    }
}