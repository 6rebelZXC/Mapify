using Dapper;
using Microsoft.Data.Sqlite;

namespace MapifyBackend.database_files;

public class DatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(string dbFileName = "database.db")
    {
        // Setting path
        _connectionString = $"Data Source={dbFileName}";
    }

    private SqliteConnection GetConnection()
    {
        SqliteConnection connection = new SqliteConnection(_connectionString);
        connection.Open();
        return connection;
    }

    public List<Strat> GetAllStrats()
    {
        using SqliteConnection db = GetConnection();
        string sql = "SELECT id, name, video_url AS videoUrl, map_id AS mapId, description " +
                     "FROM strats";
        return db.Query<Strat>(sql).ToList();
    }

    public void AddStrat(Strat strat)
    {
        using SqliteConnection db = GetConnection();
        string sql = @"INSERT INTO strats (name, video_url, map_id)
                        VALUES (@name, @videoUrl, @mapId);
                        SELECT last_insert_rowid();";
        int newId = db.QuerySingle<int>(sql, new
        {
            name = strat.Name,
            videoUrl = strat.VideoUrl,
            mapId = strat.MapId
        });

        strat.SetId(newId);
    }

    // gets an id from maps table by name(names are unique)
    public int GetMapIdByName(string mapName)
    {
        using SqliteConnection db = GetConnection();
        string sql = @"SELECT id FROM maps WHERE name = @name";
        return db.QuerySingle<int>(sql, new { name = mapName });
    }

    //returns all the data about a strat, using its id from params. Can return null if no strat has been found with this ID
    public Strat? GetStrat(int stratId)
    {
        using SqliteConnection db = GetConnection();
        string sql = "SELECT id, name, video_url AS videoUrl, map_id AS MapId, description " +
                     "FROM strats " +
                     "WHERE id = @strat_id";
        return db.QuerySingleOrDefault<Strat>(sql, new { strat_id = stratId });
    }

    // Deletes a strat by given id directly from database
    public void DeleteStrat(int id)
    {
        using SqliteConnection db = GetConnection();
        string sql = "DELETE FROM strats WHERE id=@id";
        db.Execute(sql, new { id = id });
    }

    public Map? GetMapById(int id)
    {
        using SqliteConnection db = GetConnection();
        string sql = "SELECT * FROM maps WHERE id=@id";
        return db.QuerySingleOrDefault<Map>(sql, new { id = id });
    }

    public List<Category> GetAllCategories()
    {
        using SqliteConnection db = GetConnection();
        string sql = "SELECT id, name, side FROM categories";
        return db.Query<Category>(sql).ToList();
    }

    public Category? GetCategoryById(int id)
    {
        using SqliteConnection db = GetConnection();
        string sql = "SELECT id, name, side FROM categories WHERE id=@id";
        return db.QuerySingleOrDefault<Category>(sql, new { id = id });
    }

    public void DeleteCategory(int id)
    {
        using SqliteConnection db = GetConnection();
        string sql = "DELETE FROM categories WHERE id=@id";
        db.Execute(sql, new { id = id });
    }

    public void AddCategory(Category category)
    {
        using SqliteConnection db = GetConnection();
        string sql = "INSERT INTO categories (name, side) " +
                     "VALUES (@name, @side) " +
                     "SELECT last_insert_rowid(); ";
        int newId = db.QuerySingle<int>(sql, new
        {
            name = category.Name,
            side = category.Side.ToString()
        });
        
        category.SetId(newId);
    }

    public void AssignStratToCategory(int stratId, int categoryId)
    {
        using SqliteConnection db = GetConnection();
        string sql = "INSERT INTO strat_categories (strat_id, category_id) " +
                     "VALUES (@stratId, @categoryId)";
        db.Execute(sql, new { stratId = stratId, categoryId = categoryId });
    }

    public List<Strat>? GetStratsByCategory(int categoryId)
    {
        using SqliteConnection db = GetConnection();
        string sql = "SELECT s.id, s.name, s.video_url AS videoUrl, s.map_id AS mapId, s.description" +
                     " FROM strats s" +
                     "JOIN strat_categories sc ON s.id = sc.strat_id" +
                     "WHERE sc.category_id = @categoryId";
        return db.Query<Strat>(sql, new { categoryId = categoryId }).ToList();
    }

    public string? GetCategoryNameById(int categoryId)
    {
        using SqliteConnection db = GetConnection();
        string sql = "SELECT name FROM categories WHERE id=@id";
        return db.QuerySingleOrDefault<string>(sql, new { id = categoryId });
    }
}