using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace com_parsan_student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> authenticate()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5055");
            if (disco.IsError)
            {
                return BadRequest(disco.Error);
            }
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "parsan",
                ClientSecret = "parsan-secret",
                Scope = "studentScope"
            });

            if (tokenResponse.IsError)
            {
                return BadRequest(tokenResponse.Error);
            }
            return Ok(tokenResponse.Raw);
        }
    }
}