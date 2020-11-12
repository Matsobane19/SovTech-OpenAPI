using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OpenApi.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        
        public ChuckController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("api/chuck/categories")]
        public async Task<IActionResult> Categories()
        {
            var data = await _httpClient.GetAsync("https://api.chucknorris.io/jokes/categories");

            return Ok(data.Content.ReadAsStringAsync().Result);
        }
    }
}