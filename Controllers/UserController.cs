using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), 200)]
    [ProducesResponseType(typeof(string), 400)]
    public IActionResult GetById([FromRoute] int id)
    {
        var response = new User
        {
            Id = id,
            Age = 10,
            Name = "Leonardo",
        };

        return Ok(response);
    }
}
