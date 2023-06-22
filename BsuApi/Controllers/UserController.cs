using Microsoft.AspNetCore.Mvc;
using Model;
using Repositories.Interfaces;

namespace DbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IBaseRepository<User> Data { get; set; }

    public UserController(IBaseRepository<User> baseData)
    {
        Data = baseData;
    }

    // GET api/User
    [HttpGet]
    public  JsonResult Get()
    {
        return new JsonResult(Data.GetAll());
    }

    //GET api/user/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var result = Data.Get(id);

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