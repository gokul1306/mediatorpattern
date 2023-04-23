
using Mediator_pattern.CQRS;
using MediatR;
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
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetProductByIdQuery { Id = id }));
        }
         [HttpPut("Update")]
        public async Task<IActionResult> Update( UpdateProductCommand command)
        {
            
            return Ok(await mediator.Send(command));
        }
          [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            
            return Ok(await mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
    }
}