using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;

namespace file_upload_api.Controllers
{
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        [HttpPost("upload")]
        public IActionResult Upload([FromForm] IEnumerable<IFormFile> files)
        {
            return new ObjectResult(new
            {
                Names = string.Join(", ", files.Select(file => file.FileName).ToArray()),
                TotalSize = files.Select(file => file.Length).Sum()
            });
        }
    }
}