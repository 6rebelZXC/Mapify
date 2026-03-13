using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Dapper;

namespace MapifyBackend.database_files;

public class DatabaseInitializer
{
    private const string DbFileName = "database.db";
    private const string ConnectionString = $"Data Source={DbFileName}";

    public static void EnsureDatabaseCreated()
    {
        // if (File.Exists(DbFileName)) return;
        try
        {

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var path = Path.Combine(AppContext.BaseDirectory, "database_files", "mainschema.sql");
            string script = File.ReadAllText(path);

            using var command = new SqliteCommand(script, connection);
            command.ExecuteNonQuery();

            Console.WriteLine("Created a database");
        }
        catch (Exception e)
        {
            Console.WriteLine($"DB CREATION FAILED: {e.Message}");
            if (File.Exists(DbFileName)) File.Delete(DbFileName);
        }
    }
}