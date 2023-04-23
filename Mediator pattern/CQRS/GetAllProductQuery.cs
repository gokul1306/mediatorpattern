using Mediator_pattern.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Mediator_pattern.CQRS
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
        {
            private PDbcontext context;
            public GetAllProductQueryHandler(PDbcontext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
            {
                var productList = await context.Product.ToListAsync();
                return productList;
            }
        }
    }
     public class GetAllUserQuery : IRequest<IEnumerable<User>>
    {
        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
        {
            private PDbcontext context;
            public GetAllUserQueryHandler(PDbcontext context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<User>> Handle(GetAllUserQuery query, CancellationToken cancellationToken)
            {
                var UserList = await context.User.ToListAsync();
                return UserList;
            }
        }
    }
     public class GetAllBiddingQuery : IRequest<IEnumerable<Bidding>>
    {
        public class GetAllBiddingQueryHandler : IRequestHandler<GetAllBiddingQuery, IEnumerable<Bidding>>
        {
            private PDbcontext _context;
            public GetAllBiddingQueryHandler(PDbcontext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Bidding>> Handle(GetAllBiddingQuery query, CancellationToken cancellationToken)
            {
                var BiddingList = await _context.Bidding.ToListAsync();
                return BiddingList;
            }
        }
    }
}