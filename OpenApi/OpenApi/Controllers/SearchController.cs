using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public SearchController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet("query")]
        public async Task<IActionResult> Search(string query)
        {
            string results = "";
            string metadata = "";

            var urls = new string[]
            {
                $"https://api.chucknorris.io/jokes/search?query={query}",
                $"https://swapi.dev/api/people/?search={query}"
            };

            var requests = urls.Select
                (
                url => _httpClient.GetAsync(url)
                ).ToList();
            
            await Task.WhenAll(requests);


            foreach(var data in requests.Select(x=>x.Result))
            { 
                //break the loop if we find the results
                if (data.Content.ReadAsStringAsync().Result.Split("result")[1].Length > 6)
                {
                    results = data.Content.ReadAsStringAsync().Result;
                    metadata = $"Api belons to {data.RequestMessage.RequestUri.ToString()}";
                }
            }

            return Ok(new { metadata, results });
        }
    }
}