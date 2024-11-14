using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }

        public ICollection<Ticket> Ticket { get; set; }

        public Order(int orderId, int userId, DateTime orderDate, int total)
        {
            OrderId = orderId;
            UserId = userId;
            OrderDate = orderDate;
            Total = total;
        }
    }
}