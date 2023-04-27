
using Mediator_pattern.CQRS;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mediator_pattern.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         private IMediator mediator;
        public ProductController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllProductQuery()));
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetProductByIdQuery { Id = id }));
        }
        [AllowAnonymous]
         [HttpPut("Update")]
        public async Task<IActionResult> Update( UpdateProductCommand command)
        {
            
            return Ok(await mediator.Send(command));
        }
        [AllowAnonymous]
          [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            
            return Ok(await mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
    }
}