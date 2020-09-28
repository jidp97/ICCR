using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LaugamaCorp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _enviroment;
        public UploadController(IWebHostEnvironment enviroment)
        {
            _enviroment = enviroment;
        }
        [HttpPost]
        public async Task PostAsync()
        {

            if (HttpContext.Request.Form.Files.Any())
            {
                foreach (var file in HttpContext.Request.Form.Files)
                {
                    var path = Path.Combine(_enviroment.ContentRootPath, "upload", file.FileName);
                  
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                }

            }
        }
    }
}
