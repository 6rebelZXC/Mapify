namespace MapifyBackend.database_files;

public class Map
{
    public int Id;
    public string Name;
    
    public void SetId(int id)
    {
        Id = id;
    }
    
    public void ChangeMapName(string mapName)
    {
        Name = mapName;
    }

    public Map()
    {
        
    }
}