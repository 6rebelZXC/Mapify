namespace MapifyBackend.database_files;

public class Strat
{
    public int Id { get; private set; } //ID of the strategy in the database
    public string Name { get; private set; } //Name of the strat
    public string VideoUrl { get; private set; } //URL for the video of the strat
    
    public int MapId { get; private set; } //ID of the map

    public Strat(string stratName, string videoUrl, int mapId)
    {
        Name = stratName;
        VideoUrl = videoUrl;
        MapId = mapId;
    }
    
    public Strat(int id, string namestr, string videoUrl, int mapId)
    {
        Id = id;
        Name = namestr;
        VideoUrl = videoUrl;
        MapId = mapId;
    }

    public void ChangeStratName(string namestr)
    {
        Name = namestr;
    }

    public void ChangeStratVideoUrl(string url)
    {
        VideoUrl = url;
    }

    public void SetId(int id)
    {
        Id = id;
    }
}