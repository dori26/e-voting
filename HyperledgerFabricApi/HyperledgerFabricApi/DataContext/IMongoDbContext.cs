using HyperledgerFabricApi.Entities;
using MongoDB.Bson;

namespace HyperledgerFabricApi.DataContext;

/*TODO:DORI*/
public interface IMongoDbContext
{
    Task CreateDocument(string collectionName, BsonDocument document);

    Task<string> Login(string studentId, string password);
    Task<List<Election>> GetElections(DateTime electionStart, DateTime electionEnd);
    Task<Voter> GetVoterInfo(string studentId);
    Task<List<Candidate>> GetCandidate();


    /*Task<IEnumerable<UserFeed>> GetUserFeeds(Guid userId, string collectionName);*/
}