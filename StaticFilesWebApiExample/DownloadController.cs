using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StaticFilesWebApiExample
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public DownloadController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("{token}")]
        public FileResult Get(string token)
        {
            var repository = new FilesRepository();

            var file = repository.FindFileByToken(token);

            //Build the File Path.
            string path = Path.Combine(_environment.WebRootPath, "Files/") + file.FileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", file.FileName);
        }
    }
}
