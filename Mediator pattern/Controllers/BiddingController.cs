using Mediator_pattern.CQRS;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mediator_pattern.Controllers
{
    [Authorize]   
    [Route("api/[controller]")]
    [ApiController]
    public class BiddingController : ControllerBase
    {
          private IMediator mediator;
        public BiddingController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllBiddingQuery());
            var answer = result.Select(Bidding => new{
                id = Bidding.Id,
                bidAmount = Bidding.BidAmount,
                productId = Bidding.ProductId,
                name = Bidding.User.FirstName,
                email = Bidding.User.Email,
                phoneNumber = Bidding.User.PhoneNumber,
            });
            return Ok(answer);
        }
        [AllowAnonymous]
        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBiddingCommand command)
        {
            int currentUser=Convert.ToInt32(User.FindFirst("UserId")?.Value);
            command.UserId=currentUser;
            return Ok(await mediator.Send(command));
        }
        [AllowAnonymous]
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetBiddingByIdQuery { Id = id }));
        }
        [AllowAnonymous]
         [HttpPut("Update")]
        public async Task<IActionResult> Update( UpdateBiddingCommand command)
        {
            int currentUser=Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(await mediator.Send(command));
        }
        [AllowAnonymous]
          [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            
            return Ok(await mediator.Send(new DeleteBiddingByIdCommand { Id = id }));
        }
    }
}