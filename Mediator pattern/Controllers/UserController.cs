
using Mediator_pattern.CQRS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mediator_pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator mediator;
        public UserController(IMediator _mediator)
        {
            mediator = _mediator;
        }
          [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllUserQuery()));
        }
          [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetUserByIdQuery { Id = id }));
        }
         [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await mediator.Send(command));
        }
             [HttpPut("Update")]
        public async Task<IActionResult> Update( UpdateUserCommand command)
        {
            
            return Ok(await mediator.Send(command));
        }
          [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            
            return Ok(await mediator.Send(new DeleteUserByIdCommand { Id = id }));
        }
    }
}