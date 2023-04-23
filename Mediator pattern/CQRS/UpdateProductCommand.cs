using Mediator_pattern.Models;
using MediatR;

namespace Mediator_pattern.CQRS
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id {get; set;} 
        public string productname { get; set; }
        public int price { get; set; }
        public string ShortDescription {get; set;}
        public string Category{get;set;}
        
        public DateTime BidEndDate{get;set;}
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private PDbcontext context;
            public UpdateProductCommandHandler(PDbcontext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = context.Product.Where(a => a.Id == command.Id).FirstOrDefault();

                if (product == null)
                {
                    return default;
                }
                else
                {
                product.ProductName = command.productname;
                product.StratingPrice = command.price;
                product.Category = command.Category;
                product.ShortDescription = command.ShortDescription;
                product.BidEndDate = command.BidEndDate;
                    await context.SaveChangesAsync();
                    return product.Id;
                }
            }
        }
    }
     public class UpdateUserCommand : IRequest<int>
    {
        public int Id {get; set;} 
        public string FirstName{get;set;}
        public string LastName {get;set;}
        public string  Address {get;set;}
        public string City{get;set;}
        public string State {get;set;}
        public int Pincode{get;set;}
        public string Email{get;set;}
        public string Password {get;set;}
        public string PhoneNumber{get;set;}
        
        public DateTime BidEndDate{get;set;}
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private PDbcontext _context;
            public UpdateUserCommandHandler(PDbcontext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var User = _context.User.Where(a => a.Id == command.Id).FirstOrDefault();

                if (User == null)
                {
                    return default;
                }
                else
                {
                User.FirstName= command.FirstName;
                User.LastName = command.LastName;
                User.Address = command.Address;
                User.City = command.City;
                User.Pincode = command.Pincode;
                User.Email = command.Email;
                User.Password = command.Password;
                User.PhoneNumber = command.PhoneNumber;
                User.State=command.State;
                    await _context.SaveChangesAsync();
                    return User.Id;
                }
            }
        }
    }
    public class UpdateBiddingCommand : IRequest<int>
    {
        public int Id {get; set;} 
        public int UserId{ get; set; }
        public int ProductId{ get; set; }
        public int BidAmount{ get; set; }
        
        public DateTime BidEndDate{get;set;}
        public class UpdateBiddingCommandHandler : IRequestHandler<UpdateBiddingCommand, int>
        {
            private PDbcontext _context;
            public UpdateBiddingCommandHandler(PDbcontext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateBiddingCommand command, CancellationToken cancellationToken)
            {
                var Bidding = _context.Bidding.Where(a => a.Id == command.Id).FirstOrDefault();

                if (Bidding == null)
                {
                    return default;
                }
                else
                {
                 Bidding.UserId= command.UserId;
                Bidding.ProductId = command.ProductId;
                Bidding.BidAmount = command.BidAmount;
                    await _context.SaveChangesAsync();
                    return Bidding.Id;
                }
            }
        }
    }
}