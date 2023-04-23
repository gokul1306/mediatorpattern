using System.ComponentModel.DataAnnotations;

namespace Mediator_pattern.Models
{
    public class User
    {
        [Key]
        public int Id{get;set;}
        public string FirstName{get;set;}
        public string LastName {get;set;}
        public string  Address {get;set;}
        public string City{get;set;}
        public string State {get;set;}
        public int Pincode{get;set;}
        public string Email{get;set;}
        public string Password {get;set;}
        public string PhoneNumber{get;set;}

        public virtual ICollection<Bidding> Biddings{ get; set; }

    }
}