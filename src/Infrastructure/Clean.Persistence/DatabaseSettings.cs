namespace Clean.Persistence;

public class DatabaseSettings
{
    public string MSSQLServerConnection { get; set; } = string.Empty;
    public string MySQLConnection { get; set; } = string.Empty;
    public string PostgreSQLConnection { get; set; } = string.Empty;
    public string SQLiteConnection { get; set; } = string.Empty;
}
