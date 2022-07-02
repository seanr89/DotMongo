
namespace MongoAPI.Models;

public class AppDbSettings
{
    public string? EventsCollectionName { get; set; }
    public string? EventTypesCollectionName { get; set; }
    public string? UsersCollectionName { get; set; }
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
}
