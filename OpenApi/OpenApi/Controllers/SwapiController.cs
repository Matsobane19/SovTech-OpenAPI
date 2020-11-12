using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenAPI.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public SwapiController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("api/swapi/people")]
        public async Task<IActionResult> People()
        {
            var data = await _httpClient.GetAsync("https://swapi.dev/api/people/");

            return Ok(data.Content.ReadAsStringAsync().Result);
        }

    }
}