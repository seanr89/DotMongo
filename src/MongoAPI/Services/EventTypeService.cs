

using MongoAPI.Models;
using MongoDB.Driver;

namespace MongoAPI.Services;

public class EventTypeService
{
    private readonly IMongoCollection<EventType> _eventtypes;
    private readonly ILogger<EventTypeService> _logger;
    public EventTypeService(AppDbSettings settings, ILogger<EventTypeService> logger)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _eventtypes = database.GetCollection<EventType>(settings.EventTypesCollectionName);
        _logger = logger;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<List<EventType>> GetAllAsync()
    {
        _logger.LogInformation("EventTypesService: GetAllAsync");
        return await _eventtypes.Find(s => true).ToListAsync();
    }
}