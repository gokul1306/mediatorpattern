using System.ComponentModel.DataAnnotations.Schema;

namespace Mediator_pattern.Models
{
    public class Bidding
    {
        public int Id{ get; set; }

        [ForeignKey("UserId")]
        public int UserId{ get; set; }

        [ForeignKey("ProductId")]
        public int ProductId{ get; set; }
        public int BidAmount{ get; set; }

        public virtual User User{ get; set; }
        public virtual Product Product{ get; set; }
    }
}