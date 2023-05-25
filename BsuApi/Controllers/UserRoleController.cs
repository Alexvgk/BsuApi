using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories.Interfaces;

namespace BsuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private IBaseRepository<UserRole> Data { get; set; }

        public UserRoleController(IBaseRepository<UserRole> baseData)
        {
            Data = baseData;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> Get()
        {

            var result = Data.GetAll();
            return result;
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRole>> GetUser(Guid id)
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
        public async Task<ActionResult<UserRole>> CreateUser(UserRole user)
        {
            if (ModelState.IsValid)
            {
                Data.Create(user);

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
                Data.Delete(id);
                return Ok();
            }

            catch (ArgumentException)
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserRole user)
        {

            var fuser = Data.Get(user.Id);
            try
            {
                if (fuser != null)
                {
                    fuser = Data.Update(user);
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
