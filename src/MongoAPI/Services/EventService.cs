using MongoAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoAPI.Services;

public class EventService
{
    private readonly IMongoCollection<Event> _events;
    public EventService(AppDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        //this._events = events;
        _events = database.GetCollection<Event>(settings.EventsCollectionName);
    }

    public async Task<List<Event>> GetAllAsync()
    {
        return await _events.Find(s => true).ToListAsync();
    }
    public async Task<Event> GetByIdAsync(Guid id)
    {
        return await _events.Find<Event>(s => s.Id == id).FirstOrDefaultAsync();
    }
}