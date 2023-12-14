using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories.Implimentations;

namespace BsuApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private BaseRepository<News> Data { get; set; }

        public NewsController(BaseRepository<News> data)
        {
            Data = data;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> Get()
        {

            var result = await Data.GetAllAsync();
            return result;
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<News>> GetUser(Guid id)
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
        public async Task<ActionResult<News>> CreateUser(News user)
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
        public async Task<IActionResult> UpdateUser([FromBody] News user)
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
