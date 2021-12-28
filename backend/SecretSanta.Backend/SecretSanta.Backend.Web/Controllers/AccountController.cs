using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Backend.Foundation.UserServices.Commands;
using SecretSanta.Backend.Foundation.UserServices.Models;
using SecretSanta.Backend.Foundation.UserServices.Queries;

namespace SecretSanta.Backend.Web.Controllers;

public class AccountController : ApiControllerBase
{
    private readonly IMediator _mediator;


    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    [Route("register")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegistrationDto registrationDto)
    {
        var user = new UserDto
        {
            Name = registrationDto.Name,
            Email = registrationDto.Email
        };

        var command = new RegisterCommand(user, registrationDto.Password, true);

        var result = await _mediator.Send(command);

        if (result is null)
        {
            return BadRequest(registrationDto);
        }

        return Ok(result);
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(GetUsersQuery command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var command = new GetByIdQuery(id);
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return NotFound(command);
        }

        return Ok(result);
    }
}