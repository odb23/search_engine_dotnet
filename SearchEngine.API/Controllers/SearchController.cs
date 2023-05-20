using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SearchEngine.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        [HttpGet("search")]
        public string Get()
        {
            return "Ok";
        }


        [HttpPost("upload")]
        public string UploadDocument([FromBody] FileInfo file)
        {
            return "Upload";
        }
    }
}
