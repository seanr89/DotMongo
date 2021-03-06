using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Models;

public class Event
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    
    public EventType Type { get; set; }


    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
