using MongoDB.Bson.Serialization.Attributes;

namespace HyperledgerFabricApi.Entities;

[BsonIgnoreExtraElements]
public class Voter
{
    /*[BsonId]
    public Guid UserId { get; set; }
    [BsonDateTimeOptions(Kind : DateTimeKind.Utc)]
    [BsonElement("CreatedAt")]
    public DateTime? CreatedAt { get; set; }
    [BsonElement("Feed")]
    public string Feed { get; set; }*/
    
    [BsonElement("StudentId")]
    public string StudentId { get; set; }
    
    [BsonElement("Password")]
    public string Password { get; set; }
    
    [BsonElement("Name")]
    public string Name { get; set; }
    
    [BsonElement("Semester")]
    public string semester { get; set; }
    
    [BsonElement("Faculty")]
    public string Faculty { get; set; }
    
    [BsonElement("Email")]
    public string Email { get; set; }
    
    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    [BsonElement("CreatedAt")]
    public DateTime? CreatedAt { get; set; }
}
