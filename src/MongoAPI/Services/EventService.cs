using MongoAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoAPI.Services;

public class EventService
{
    private readonly IMongoCollection<Event> _events;
    private readonly ILogger<EventService> _logger;
    public EventService(AppDbSettings settings, ILogger<EventService> logger)
    {
        // var client = new MongoClient(new MongoClientSettings
        //     {
        //         Server = new MongoServerAddress("localhost", 27017),
        //         Credential = MongoCredential.CreateCredential(settings.DatabaseName, "sean", "password"),
        //         UseSsl = true,
        //         VerifySslCertificate = false,
        //         SslSettings = new SslSettings
        //         {
        //             CheckCertificateRevocation = false
        //         }
        //     });
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _events = database.GetCollection<Event>(settings.EventsCollectionName);
        _logger = logger;
    }

    public async Task<List<Event>> GetAllAsync()
    {
        _logger.LogInformation("EventService: GetAllAsync");
        return await _events.Find(s => true).ToListAsync();
    }
    public async Task<Event> GetByIdAsync(Guid id)
    {
        _logger.LogInformation("EventService: GetByIdAsync");
        return await _events.Find<Event>(s => s.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Event> CreateAsync(Event evnt)
    {
        _logger.LogInformation("EventService: CreateAsync");
        await _events.InsertOneAsync(evnt);
        return evnt;
    }
    public async Task UpdateAsync(Guid id, Event evnt)
    {
        await _events.ReplaceOneAsync(s => s.Id == id, evnt);
    }
    public async Task DeleteAsync(Guid id)
    {
        await _events.DeleteOneAsync(s => s.Id == id);
    }
}