using Microsoft.AspNetCore.Mvc;
using MyBackendAPI.DTOs.OrderDtos;
using MyBackendAPI.DTOs.TicketDtos;
using MyBackendAPI.Models;
using MyBackendAPI.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
namespace MyBackendAPI.Controllers
{
    public static class OrderEndpoint
    {
        public static void configureOrderEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("order");
            group.MapGet("/", GetAllOrders);
            group.MapGet("/getOrdersByUserId/{userId:int}", GetOrdersById);
            group.MapPost("/", CreateOrder);
            group.MapDelete("/", DeleteOrder);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        //Get all
        public static async Task<IResult> GetAllOrders(IOrderRepository repository)
        {
            var orders = await repository.GetOrders();
            return TypedResults.Ok(orders);
        }
        //Get by user
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetOrdersById(IOrderRepository orderRepository, IUserRepository userRepository, int userId)
        {
            var user = await userRepository.GetUser(userId);
            if(user == null)
            {
                return TypedResults.NotFound("User does not exist");
            }
            var orders = await orderRepository.GetOrdersByUserId(userId);
            return TypedResults.Ok(orders);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //Create
        public static async Task<IResult> CreateOrder(IOrderRepository orderRepository, IUserRepository userRepository, CreateOrderDto model)
        {
            try
            {
                Order order = new Order();
                order.UserId = model.UserId;
                order.OrderDate = DateTime.UtcNow;

                List<Ticket> TicketList = new List<Ticket>();
                int total = 0;
                foreach (CreateTicketDto item in model.Ticket)
                {
                    Ticket ticket = new Ticket();
                    ticket.Price = item.Price;
                    total += item.Price;
                    ticket.ScreeningId = item.ScreeningId;
                    TicketList.Add(ticket);
                }
                order.Ticket = TicketList;
                order.Total = total;

                var orderCreated = await orderRepository.CreateOrder(order);
                return TypedResults.Ok(orderCreated);
            }
            catch(Exception e)
            {
                return TypedResults.BadRequest("Error: " + e);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteOrder(IOrderRepository orderRepository, int id)
        {
            var orderDeleted = await orderRepository.DeleteOrder(id);
            if (orderDeleted == null)
            {
                return TypedResults.NotFound("Order does not exist");
            }
            return TypedResults.Ok(orderDeleted);
        }

    }
}
