using Microsoft.AspNetCore.Mvc;
using PtmScreeCaptureServer.Model;
using PtmScreeCaptureServer.Services;

namespace PtmScreeCaptureServer.Controllers
{
    public class BaseController<T> : ControllerBase where T : IMongoDocument
    {
        private readonly MongoDbService _mongoDbService;

        public BaseController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public async Task<List<T>> Get() // where T: IMongoDocument
        {
            var docList = await _mongoDbService.GetAsync<T>();
            return docList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(string id) // where T : IMongoDocument
        {
            var userRole = await _mongoDbService.GetAsync<T>(id);
            if (userRole == null)
            {
                return NotFound();
            }

            return userRole;
        }

        [HttpPost]
        public async Task<IActionResult> Post(T doc) // where T : IMongoDocument
        {
            await _mongoDbService.InsertAsync<T>(doc);
            return CreatedAtAction(nameof(Post), new { id = doc.Id }, doc);
        }

        [HttpPut]
        public async Task<IActionResult> Update(T doc)  // where T: IMongoDocument
        {
            await _mongoDbService.UpdateAsync(doc.Id, doc);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)  // where T : IMongoDocument
        {
            await _mongoDbService.DeleteAsync<T>(id);

            return NoContent();
        }
    }
}
