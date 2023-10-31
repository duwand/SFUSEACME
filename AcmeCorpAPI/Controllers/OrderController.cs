using AcmeCorpAPI.DataContext;
using AcmeCorpAPI.Models;
using AcmeCorpAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorpAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;


        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                var orders = _orderService.GetAllOrders();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetOrderbyID([FromRoute] int id)
        {
            var order = _orderService.GetOrderbyCustomerID(id);

            if (order == null)
            {
                return NotFound("Order doesnt exists.");
            }
            return Ok(order);
        }


        //[HttpPut]
        //[Route("update/{id}")]
        //public IActionResult UpdateOrderbyID([FromRoute] int id, [FromBody] UpdateOrder updateOrder)
        //{
        //    var orderfromDB = appDbContext.Orders.Find(id);

        //    if (orderfromDB == null)
        //    {
        //        return NotFound();
        //    }

        //    orderfromDB.DeliveryAddress = updateOrder.DeliveryAddress;
        //    orderfromDB.CustomerPhone = updateOrder.CustomerPhone;
        //    orderfromDB.CustomerEmail = updateOrder.CustomerEmail;
        //    orderfromDB.Status = updateOrder.Status;
            

        //    appDbContext.Orders.Update(orderfromDB);
        //    appDbContext.SaveChanges();

        //    return Ok(orderfromDB);
        //}
    }
}
