using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

[ApiController]
[Route("api/[controller]")]
[EnableRateLimiting("TokenBucket")]
public class RandomStringController : ControllerBase
{
    private static readonly string[] RandomStrings = new[]
    {
        "Alpha", "Beta", "Gamma", "Delta", "Epsilon"
    };

    [HttpGet]
    [Route("randomstring")]
    public ActionResult<string> GetRandomString()
    {
        var randomString = RandomStrings[Random.Shared.Next(RandomStrings.Length)];
        return Ok(randomString);
    }
}
