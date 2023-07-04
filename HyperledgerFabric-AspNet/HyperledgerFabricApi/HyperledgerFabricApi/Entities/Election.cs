using MongoDB.Bson.Serialization.Attributes;

namespace HyperledgerFabricApi.Entities;

[BsonIgnoreExtraElements]
public class Election 
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

    [BsonElement("Candidate")]
    public string Candidate { get; set; }

    [BsonElement("ElectionType")]
    public string ElectionType { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    [BsonElement("ElectionStart")]
    public DateTime? ElectionStart { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
    [BsonElement("ElectionEnd")]
    public DateTime ElectionEnd { get; set; }


}
