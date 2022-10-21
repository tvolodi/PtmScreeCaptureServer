using Microsoft.AspNetCore.Mvc;
using PtmScreeCaptureServer.Services;

namespace PtmScreenCaptureServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScreenshotController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile files) // where T : IMongoDocument
        {
            //long size = files.Sum(f => f.Length);

            //foreach (var formFile in files)
            //{
            //    if (formFile.Length > 0)
            //    {
            //        var filePath = 
            //            Path.GetRandomFileName();

            //        using (var stream = System.IO.File.Create(filePath))
            //        {
            //            await formFile.CopyToAsync(stream);
            //        }
            //    }
            //}
            return Ok(new { count = 1});
        }
    }
}
