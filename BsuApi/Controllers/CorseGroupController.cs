using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories.Interfaces;

namespace DbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorseGroupController : ControllerBase
    {
        private IBaseRepository<CourseGroup> Data { get; set; }

        public CorseGroupController(IBaseRepository<CourseGroup> baseData)
        {
            Data = baseData;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseGroup>>> Get()
        {

            var result = Data.GetAll();
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCode(Guid id)
        {
            try
            {
                Data.Delete(id);
                return Ok();
            }

            catch (ArgumentException)
            {
                return NoContent();
            }
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseGroup>> GetCode(Guid id)
        {
            var result = Data.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<CourseGroup>> CreateCode(CourseGroup code)
        {
            if (ModelState.IsValid)
            {
                Data.Create(code);

                return CreatedAtAction(nameof(GetCode), new { id = code.Id }, code);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCode(int id, [FromBody] CourseGroup code)
        {
            var fcode = Data.Get(code.Id);
            try
            {
                if (fcode != null)
                {
                    fcode = Data.Update(code);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
