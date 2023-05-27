
using G1GLK1_HFT_2021221.Logic;
using G1GLK1_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace G1GLK1_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        IOrderLogic ol;

        public OrderController(IOrderLogic ol)
        {
            this.ol = ol;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return ol.GetOrders();
        }

        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return ol.GetOrder(id);
        }

        [HttpPost]
        public void Post([FromBody] Order value)
        {
            ol.CreateOrder(value);
        }

        [HttpPut]
        public void PutName([FromBody] Order value)
        {
            ol.UpdateOrder(value.OrderId, value.Food, value.Price);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ol.DeleteOrder(id);
        }

        [HttpGet("{id}/name")]
        public string GetConsumerName(int id)
        {
          return  ol.GetConsumerName(id);
        }

        [HttpGet("{id}/address")]
        public string GetConsumerAddress(int id)
        {
          return  ol.GetConsumerAddress(id);
        }
    }
}
