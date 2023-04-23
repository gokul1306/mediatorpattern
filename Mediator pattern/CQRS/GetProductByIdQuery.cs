using Mediator_pattern.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator_pattern.CQRS
{
     public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            private PDbcontext context;
            public GetProductByIdQueryHandler(PDbcontext context)
            {
                this.context = context;
            }
            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await context.Product.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return product;
            }
        }
    }
        public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private PDbcontext context;
            public GetUserByIdQueryHandler(PDbcontext context)
            {
                this.context = context;
            }
            public async Task<User> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var User = await context.User.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return User;
            }
        }
    }
           public class GetBiddingByIdQuery : IRequest<Bidding>
    {
        public int Id { get; set; }
        public class GetBiddingByIdQueryHandler : IRequestHandler<GetBiddingByIdQuery, Bidding>
        {
            private PDbcontext _context;
            public GetBiddingByIdQueryHandler(PDbcontext context)
            {
                _context = context;
            }
            public async Task<Bidding> Handle(GetBiddingByIdQuery query, CancellationToken cancellationToken)
            {
                var Bidding = await _context.Bidding.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                return Bidding;
            }
        }
    }
}