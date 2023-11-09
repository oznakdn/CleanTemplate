namespace Clean.Persistence.Options.Interfaces;

public interface IMongoOption
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
