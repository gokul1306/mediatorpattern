using Mediator_pattern.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator_pattern.CQRS
{
     public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private PDbcontext context;
            public DeleteProductByIdCommandHandler(PDbcontext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await context.Product.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                context.Product.Remove(product);
                await context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
    public class DeleteUserByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, int>
        {
            private PDbcontext _context;
            public DeleteUserByIdCommandHandler(PDbcontext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                var user = await _context.User.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
        }
    }
     public class DeleteBiddingByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBiddingByIdCommandHandler : IRequestHandler<DeleteBiddingByIdCommand, int>
        {
            private PDbcontext _context;
            public DeleteBiddingByIdCommandHandler(PDbcontext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBiddingByIdCommand command, CancellationToken cancellationToken)
            {
                var Bidding = await _context.Bidding.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                _context.Bidding.Remove(Bidding);
                await _context.SaveChangesAsync();
                return Bidding.Id;
            }
        }
    }
}