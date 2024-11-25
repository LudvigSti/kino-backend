using MyBackendAPI.DTOs.TicketDtos;
using MyBackendAPI.Models;

namespace MyBackendAPI.DTOs.OrderDtos
{
    public class CreateOrderDto
    {
        public int UserId { get; set; }
        public ICollection<CreateTicketDto> Ticket { get; set; }
        
    }
}
