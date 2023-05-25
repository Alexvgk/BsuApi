using DbConect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Repositories.Interfaces;

namespace DbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegCodeController : ControllerBase
    {
        private IBaseRepository<RegCode> Data { get; set; }

        public RegCodeController(IBaseRepository<RegCode> baseData)
        {
            Data = baseData;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegCode>>> Get()
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
        public async Task<ActionResult<RegCode>> GetCode(Guid id)
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
        public async Task<ActionResult<RegCode>> CreateCode(RegCode code)
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
        public async Task<IActionResult> UpdateCode(int id, [FromBody] RegCode code)
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
