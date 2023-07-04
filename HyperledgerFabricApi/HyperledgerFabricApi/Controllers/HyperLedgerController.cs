using HyperledgerFabricApi.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace HyperledgerFabricApi.Controllers;
/*TODO:DORI*/
[ApiController]
[Route("api")]
public class HyperLedgerController : ControllerBase
{
    private readonly IMongoDbContext _mongoDbContext;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public HyperLedgerController(IMongoDbContext mongoDbContext)
    {
        _mongoDbContext = mongoDbContext;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(string studentId, string password)
    {
        await _mongoDbContext.Login(studentId, password);
        return Ok();
    }

    [HttpGet("voter-info")]
    public async Task<IActionResult> VoterInfo(string studentId)
    {
        return Ok(await _mongoDbContext.GetVoterInfo(studentId));
    }

    [HttpGet("candidates")]
    public async Task<IActionResult> Candidates()
    {
        return Ok(await _mongoDbContext.GetCandidate());
    }

    [HttpGet("elections")]
    public async Task<IActionResult> Get(DateTime electionStart, DateTime electionEnd)
    {
        return Ok(await _mongoDbContext.GetElections(electionStart, electionEnd));
    }
}