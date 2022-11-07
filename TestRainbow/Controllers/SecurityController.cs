using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace TestRainbow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                return BadRequest(disco.Error);
            }
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "rainbow.client",
                ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
                Scope = "scope1"
            });

            return tokenResponse.IsError ? BadRequest(tokenResponse.Error) : new ObjectResult(tokenResponse.AccessToken);
        }
    }
}
