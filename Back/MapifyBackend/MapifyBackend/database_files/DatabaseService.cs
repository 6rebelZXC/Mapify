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
        string sql = @"INSERT INTO strat (name, videourl)
                        VALUES (@name, @videourl);
                        SELECT last_insert_rowid();";
        int newId = db.QuerySingle<int>(sql, new
        {
            name = strat.Name,
            videourl = strat.VideoUrl
        });
        // 3. Присваиваем ID нашему объекту через Reflection или изменив доступ к Id
        // Но проще всего в классе Strat сделать Id доступным для установки внутри этого метода
        typeof(Strat).GetProperty("Id")?.SetValue(strat, newId);
    }
}