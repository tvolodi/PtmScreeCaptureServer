using Microsoft.AspNetCore.Mvc;
using PtmScreeCaptureServer.Model;
using PtmScreeCaptureServer.Services;

namespace PtmScreeCaptureServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        public UserController(MongoDbService mongoDbService) : base(mongoDbService)
        {
        }


    }
}
