using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoAPI.Models;

/// <summary>
/// New type class to support future identification of events
/// </summary>
public class EventType
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
