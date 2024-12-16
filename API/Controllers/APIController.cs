using System.Formats.Asn1;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IRepository _IRepository;

        public APIController(IRepository repository)
        {
            _IRepository = repository;
        }

        [HttpGet]
        [Route("GetAll_Table")]
        public async Task<ActionResult<IEnumerable<object>>> GetAll_Table()
        {
            var result = await _IRepository.GetAll_table();
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateAll-Table")]
        public async Task<ActionResult<IEnumerable<object>>> CreateAll_Table([FromBody] object entity)
        {
            await _IRepository.CreateAll(entity);
            return Ok(entity);
        }


        [HttpPut]
        [Route("EditAll-Table")]
        public async Task<ActionResult<IEnumerable<object>>> EditAll_Table([FromBody] object entity)
        {
            await _IRepository.EditAll(entity);
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAll_Table(int id)
        {
            await _IRepository.DeketeAll<object>(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(int id)
        {
            var entity = await _IRepository.GetById<object>(id); 
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
