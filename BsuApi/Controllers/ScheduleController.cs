using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories.Interfaces;

namespace DbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IBaseRepository<Schedule> Data { get; set; }

        public ScheduleController(IBaseRepository<Schedule> baseData)
        {
            Data = baseData;
        }

        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> Get()
        {

            var result = Data.GetAll();
            return result;
        }

        //GET api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetUser(Guid id)
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
        public async Task<ActionResult<Schedule>> CreateUser(Schedule user)
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
        public async Task<IActionResult> UpdateUser([FromBody] Schedule user)
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
