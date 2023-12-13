using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories.Implimentations;
using Repositories.Interfaces;

namespace DbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private BaseRepository<User> Data { get; set; }

    public UserController(BaseRepository<User> baseData)
    {
        Data = baseData;
    }

    // GET api/User
    [HttpGet]
    public async Task<JsonResult> Get()
    {
        return new JsonResult( await Data.GetAllAsync());
    }

    //GET api/user/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var result = await Data.GetByIdAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(GetUser), result);
    }

    // POST api/users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
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
            return  Ok();
        }

        catch (ArgumentException)
        {
            return  NoContent();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
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