using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Interfaces;

namespace DbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UIDController : ControllerBase
    {
        private IBaseRepository<UID> Data { get; set; }

        public UIDController(IBaseRepository<UID> baseData)
        {
            Data = baseData;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UID>>> Get()
        {

            var result =  Data.GetAll();
            return result;
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UID>> GetPass(Guid id)
        {
            if (Data.Get(id) is UID result)
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
                Data.Create(pass);

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
                Data.Delete(id);
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
            var fuser = Data.Get(pass.Id);
            try
            {
                if (fuser != null)
                {
                    fuser = Data.Update(pass);
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
