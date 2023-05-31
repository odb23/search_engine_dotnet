using iText.Signatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;
using System.Runtime.CompilerServices;

namespace SearchEngine.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService SearchService;

        public SearchController (ISearchService searchService)
        {
            this.SearchService = searchService;
        }

        [HttpGet("search")]
        public IActionResult Get([FromQuery] string query)
        {
            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var res = this.SearchService.GetSearchResult(new SearchQuery(query));
             
            Console.WriteLine($"Search results for \"{query}\" took {DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTime}ms");
            return Ok(res); 
        }


       /* [HttpPost("upload")]
        public string UploadDocument([FromBody] FileInfo file)
        {
            return "Upload";
        }*/
    }
}
