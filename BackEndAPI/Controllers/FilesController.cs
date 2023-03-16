using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System;
using System.IO;

namespace BackEndAPI.Controllers
{
    [Route("api/GetFile")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // GET api/values  
        [HttpGet]
        public IActionResult GetFile(string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Assets", filename);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/octet-stream", filename);
        }
    }
}
