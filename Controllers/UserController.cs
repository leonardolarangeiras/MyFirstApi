using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Communication.Requests;
using MyFirstApi.Communication.Response;

namespace MyFirstApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestRegisterUserJson request)
    {
        var response = new ResponseRegisteredUserJson
        {
            Id = 1,
            Name = request.Name,
        };

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestUpdateUserJson request)
    {
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete()
    {
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public IActionResult List()
    {
        var users = new List<User>
        {
            new User { Id = 1, Age = 10, Name = "Leonardo" },
            new User { Id = 2, Age = 20, Name = "Maria" }
        };

        return Ok(users);
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ChangePassword([FromBody] RequestChangePasswordJson request)
    {
        return NoContent();
    }
}
