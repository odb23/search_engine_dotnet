using iText.Signatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.API.Interfaces;
using SearchEngine.API.Models;

namespace SearchEngine.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchService SearchService;

        public SearchController (ISearchService searchService)
        {
            this.SearchService = searchService; 
        }

        [HttpGet("search")]
        public IActionResult Get([FromQuery] string query)
        {
            var res = this.SearchService.GetSearchResult(new SearchQuery(query));
            
            return Ok(res); 
        }


        [HttpPost("upload")]
        public string UploadDocument([FromBody] FileInfo file)
        {
            return "Upload";
        }
    }
}
