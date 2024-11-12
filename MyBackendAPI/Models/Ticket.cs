using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackendAPI.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int Price { get; set; }

        public int ScreeningId { get; set; }
        [ForeignKey("ScreeningId")]
        public Screening Screening { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        

        public Ticket(int ticketId,  int price, int screeningId, int orderId)
        {
            TicketId = ticketId;
            Price = price;
            ScreeningId = screeningId;
            OrderId = orderId;
        }
    }
}