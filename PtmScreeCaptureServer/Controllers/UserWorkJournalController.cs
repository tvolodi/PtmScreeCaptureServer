using Microsoft.AspNetCore.Mvc;
using PtmScreeCaptureServer.Model;
using PtmScreeCaptureServer.Services;

namespace PtmScreeCaptureServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWorkJournalController : BaseController<UserWorkJournal>
    {
        public UserWorkJournalController(MongoDbService mongoDbService) : base(mongoDbService)
        {
        }
    }
}
