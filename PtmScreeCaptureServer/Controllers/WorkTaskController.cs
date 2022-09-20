using Microsoft.AspNetCore.Mvc;
using PtmScreeCaptureServer.Model;
using PtmScreeCaptureServer.Services;

namespace PtmScreeCaptureServer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorkTaskController : BaseController<WorkTask> 
    {
        public WorkTaskController(MongoDbService mongoDbService) : base(mongoDbService)
        {
        }
    }
}
