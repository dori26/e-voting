using MongoDB.Bson.Serialization.Attributes;

namespace HyperledgerFabricApi.Entities;

[BsonIgnoreExtraElements]
public class Candidate
{
    /*[BsonId]
    public Guid UserId { get; set; }
    [BsonDateTimeOptions(Kind : DateTimeKind.Utc)]
    [BsonElement("CreatedAt")]
    public DateTime? CreatedAt { get; set; }
    [BsonElement("Feed")]
    public string Feed { get; set; }*/
    
    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("StudentId")]
    public string StudentId { get; set; }

    [BsonElement("Faculty")]
    public string Faculty { get; set; }

    [BsonElement("ElectionType")]
    public string ElectionType { get; set; }

    [BsonElement("Email")]
    public string Email { get; set; }

}
