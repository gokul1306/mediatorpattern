using System.ComponentModel.DataAnnotations;

namespace Mediator_pattern.Models
{
    public class Product
    {
        [Key]
        public int Id{get;set;}
        public string ProductName{get;set;}
        public string ShortDescription {get; set;}
        public string DetailedDescription{get;set;}
        public string Category{get;set;}
        public int StratingPrice{get;set;}
        public DateTime BidEndDate{get;set;}

        public virtual ICollection<Bidding> Biddings{ get; set; }
    }
}