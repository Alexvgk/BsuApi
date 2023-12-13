using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories.Implimentations;
using Repositories.Interfaces;

namespace BsuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private BaseRepository<Role> Data { get; set; }

        public RoleController(BaseRepository<Role> baseData)
        {
            Data = baseData;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {

            var result = await Data.GetAllAsync();
            return result;
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetUser(Guid id)
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
        public async Task<ActionResult<Role>> CreateUser(Role user)
        {
            if (ModelState.IsValid)
            {
                await Data.AddAsync(user);

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
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
        public async Task<IActionResult> UpdateUser([FromBody] Role user)
        {

            var fuser = await Data.GetByIdAsync(user.Id);
            try
            {
                if (fuser != null)
                {
                    await Data.UpdateAsync(user);
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
