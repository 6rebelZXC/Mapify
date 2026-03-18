namespace MapifyBackend.database_files;

public class Map
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    
    public Map() { }
    public Map(int id, string name) { Id = id; Name = name; }
    
    public void SetId(int id) { Id = id; }
    public void SetName(string name) { Name = name; }
}