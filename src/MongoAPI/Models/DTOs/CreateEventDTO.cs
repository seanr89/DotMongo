
namespace MongoAPI.Models.DTOs;

public record CreateEventDTO
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    
    public EventType Type { get; set; }
}