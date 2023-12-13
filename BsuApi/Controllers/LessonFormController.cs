using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories.Implimentations;
using Repositories.Interfaces;

namespace DbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonFormController : ControllerBase
    {
        private BaseRepository<LessonForm> Data { get; set; }

        public LessonFormController(BaseRepository<LessonForm> baseData)
        {
            Data = baseData;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonForm>>> Get()
        {

            var result = await Data.GetAllAsync();
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCode(Guid id)
        {
            try
            {
                await Data.DeleteAsync(id);
                return Ok();
            }

            catch (ArgumentException)
            {
                return NoContent();
            }
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonForm>> GetCode(Guid id)
        {
            var result = await Data.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<LessonForm>> CreateCode(LessonForm code)
        {
            if (ModelState.IsValid)
            {
                await Data.AddAsync(code);

                return CreatedAtAction(nameof(GetCode), new { id = code.Id }, code);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCode(int id, [FromBody] LessonForm code)
        {
            var fcode = await Data.GetByIdAsync(code.Id);
            try
            {
                if (fcode != null)
                {
                    await Data.UpdateAsync(code);
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
