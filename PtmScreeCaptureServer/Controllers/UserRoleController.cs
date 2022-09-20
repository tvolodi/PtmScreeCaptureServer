using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PtmScreeCaptureServer.Model;
using PtmScreeCaptureServer.Services;

namespace PtmScreeCaptureServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;

        public UserRoleController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public async Task<List<UserRole>> Get()
        {
            var userRoles = await _mongoDbService.GetAsync<UserRole>();
            return userRoles;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> Get(string id)
        {
            var userRole = await _mongoDbService.GetAsync<UserRole>(id);
            if (userRole == null)
            {
                return NotFound();
            }

            return userRole;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRole userRole)
        {
            await _mongoDbService.InsertAsync<UserRole>(userRole);
            return CreatedAtAction(nameof(Get), new { id = userRole.Id }, userRole);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserRole userRole)
        {
            await _mongoDbService.UpdateAsync(userRole.Id, userRole);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDbService.DeleteAsync<UserRole>(id);

            return NoContent();
        }

    }
}
