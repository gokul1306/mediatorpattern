using Mediator_pattern.Models;
using MediatR;

namespace Mediator_pattern.CQRS
{
    public class CreateProductCommand : IRequest<int>
    {
        public string productname { get; set; }
        public int price { get; set; }
        public string ShortDescription {get; set;}
        public string DetailedDescription{get;set;}
        public string Category{get;set;}
        
        public DateTime BidEndDate{get;set;}
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly PDbcontext context;
            public CreateProductCommandHandler(PDbcontext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();
                product.ProductName = command.productname;
                product.StratingPrice = command.price;
                product.Category = command.Category;
                product.ShortDescription = command.ShortDescription;
                product.DetailedDescription=command.DetailedDescription;
                product.BidEndDate = command.BidEndDate;

                context.Product.Add(product);
                await context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
    public class CreateUserCommand : IRequest<int>
    {
        public string FirstName{get;set;}
        public string LastName {get;set;}
        public string  Address {get;set;}
        public string City{get;set;}
        public string State {get;set;}
        public int Pincode{get;set;}
        public string Email{get;set;}
        public string Password {get;set;}
        public string PhoneNumber{get;set;}
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly PDbcontext _context;
            public CreateUserCommandHandler(PDbcontext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var User = new User();
                User.FirstName= command.FirstName;
                User.LastName = command.LastName;
                User.Address = command.Address;
                User.City = command.City;
                User.State=command.State;
                User.Pincode = command.Pincode;
                User.Email = command.Email;
                User.Password = command.Password;
                User.PhoneNumber = command.PhoneNumber;

                _context.User.Add(User);
                await _context.SaveChangesAsync();
                return User.Id;
            }
        }
    }
    public class CreateBiddingCommand : IRequest<int>
    {
        public int UserId{ get; set; }
        public int ProductId{ get; set; }
        public int BidAmount{ get; set; }
        public class CreateBiddingCommandHandler : IRequestHandler<CreateBiddingCommand, int>
        {
            private readonly PDbcontext _context;
            public CreateBiddingCommandHandler(PDbcontext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateBiddingCommand command, CancellationToken cancellationToken)
            {
                var Bidding = new Bidding();
                Bidding.UserId= command.UserId;
                Bidding.ProductId = command.ProductId;
                Bidding.BidAmount = command.BidAmount;

                _context.Bidding.Add(Bidding);
                await _context.SaveChangesAsync();
                return Bidding.Id;
            }
        }
    }
}