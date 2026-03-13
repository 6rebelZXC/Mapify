namespace MapifyBackend.database_files;

public class Strat
{
    public int Id { get; private set; } //ID of the strategy in the database
    public string Name { get; private set; } //Name of the strat
    public string VideoUrl { get; private set; } //URL for the video of the strat

    public Strat(string stratName, string videoUrl)
    {
        Name = stratName;
        VideoUrl = videoUrl;
    }
    
    public Strat(int id, string namestr, string videoUrl)
    {
        Id = id;
        Name = namestr;
        VideoUrl = videoUrl;
    }

    public void ChangeStratName(string namestr)
    {
        Name = namestr;
    }

    public void ChangeStratVideoUrl(string url)
    {
        VideoUrl = url;
    }
}