using HyperledgerFabricApi.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace HyperledgerFabricApi.DataContext;
/*TODO:DORI*/
public class MongoDbDbContext:IMongoDbContext
{
    private readonly IMongoDatabase _dbContext;

    public MongoDbDbContext()
    {
        
        var settings = MongoClientSettings.FromConnectionString("mongodb+srv://hadrizawawi:gelombang_2001@cluster0.vmqf9p5.mongodb.net/");

        settings.LinqProvider = LinqProvider.V3;

        var client = new MongoClient(settings);
        _dbContext = client.GetDatabase("FYPDori");
    }

    private async Task CreateCollection(string name)
    {
        await _dbContext.CreateCollectionAsync(name);
    }
    
    public async Task CreateDocument(string collectionName, BsonDocument document)
    {
        var collection = _dbContext.GetCollection<BsonDocument>(collectionName);
        await collection.InsertOneAsync(document);
    }

    public async Task<string> Login(string studentId, string password)
    {
        var collection = _dbContext.GetCollection<Voter>("Voters");
        
        var userFeed = await collection.AsQueryable()
            .Where(x => x.StudentId == studentId)
            .FirstOrDefaultAsync();

        if (userFeed == null)
        {
            throw new Exception("user not found");
        }

        if (userFeed.Password == password)
        {
            return "Is logged in";
        }
        
        throw new Exception("Wrong username or password");
    }

    public Task<string> GetElections(string studentId, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<string> SignUp(string studentId, string email, string password)
    {
        var collection = _dbContext.GetCollection<Voter>("Voters");

        var userFeed = await collection.AsQueryable()
            .Where(x => x.StudentId == studentId)
            .FirstOrDefaultAsync();

        if (userFeed == null)
        {
            throw new Exception("user not found");
        }

        if (userFeed.Password == password)
        {
            return "Is logged in";
        }

        throw new Exception("Wrong username or password");
    }

    public async Task<List<Election>> GetElections(DateTime electionStart, DateTime electionEnd)
    {
        var collection = _dbContext.GetCollection<Election>("Elections");
        
        var elections = await collection.AsQueryable()
            .Where(x => x.ElectionStart >= electionStart)
            .Where(x => x.ElectionEnd <= electionEnd)
            .ToListAsync();

        if (!elections.Any())
        {
            throw new Exception("Election not found");
        }

        return elections;

    }
    
    public async Task<Voter> GetVoterInfo(string studentId)
    {
        var voterDb = _dbContext.GetCollection<Voter>("Voters");
        
        var voter = await voterDb.AsQueryable()
            .Where(x => x.StudentId == studentId)
            .FirstOrDefaultAsync();


        if (voter == null)
        {
            throw new Exception("Voter not found");
        }

        return voter;

    }
    public async Task<List<Candidate>> GetCandidate()
    {
        var candidatedb = _dbContext.GetCollection<Candidate>("Candidates");

        var candidate = await candidatedb.AsQueryable().ToListAsync();

        if (!candidate.Any())
        {
            throw new Exception("Candidate not found");
        }

        return candidate;

    }

    /*public async Task<IEnumerable<UserFeed>> GetUserFeeds(Guid userId, string collectionName)
    {
        var collection = _dbContext.GetCollection<UserFeed>(collectionName);

        var userFeeds = await collection.AsQueryable()
            .Where(x => x.UserId == userId).Select(x => x).ToListAsync();
        return userFeeds;
    }*/
}