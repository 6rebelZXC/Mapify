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
        string sql = "DELETE FROM strats WHERE id=:id";
        db.Query(sql, new { id = id });
    }

    public string? GetMapById(int id)
    {
        using SqliteConnection db = GetConnection();
        string sql = "SELECT name FROM maps WHERE id=:id";
        return db.QuerySingleOrDefault<string>(sql, new { id = id });
    }
}