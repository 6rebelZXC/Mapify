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
        return db.Query<Strat>("SELECT * FROM strat").ToList();
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

    public int GetMapIdByName(string mapName)
    {
        using SqliteConnection db = GetConnection();
        string sql = @"SELECT id FROM maps WHERE name = @name";
        return db.QuerySingle<int>(sql, new { name = mapName });
    }
}