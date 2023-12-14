using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Implimentations;
using Repositories.Interfaces;

namespace DbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIDController : ControllerBase
    {
        private BaseRepository<UID> Data { get; set; }

        public UIDController(BaseRepository<UID> baseData)
        {
            Data = baseData;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UID>>> Get()
        {

            var result =  await Data.GetAllAsync();
            return result;
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UID>> GetPass(Guid id)
        {
            if (await Data.GetByIdAsync(id) is UID result)
            {
                return result;
            }

            return NotFound();
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<UID>> CreatePass(UID pass)
        {
            if (ModelState.IsValid)
            {
                await Data.AddAsync(pass);

                return CreatedAtAction(nameof(GetPass), new { id = pass.Id }, pass);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePass(Guid id)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePass([FromBody] UID pass)
        {
            try
            {
                await Data.UpdateAsync(pass);
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
