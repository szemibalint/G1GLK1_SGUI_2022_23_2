
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
    public class ConsumerController : ControllerBase
    {

        IConsumerLogic cl;

        public ConsumerController(IConsumerLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public IEnumerable<Consumer> Get()
        {
            return cl.GetConsumers();
        }

        [HttpGet("{id}")]
        public Consumer Get(int id)
        {
            return cl.GetConsumer(id);
        }

        [HttpPost]
        public void Post([FromBody] Consumer value)
        {
            cl.CreateConsumer(value);
        }

        [HttpPut("address")]
        public void PutAddress([FromBody] Consumer value)
        {
            cl.UpdateAdress(value.ConsumerId, value.Address);
        }

        [HttpPut("name")]
        public void PutName([FromBody] Consumer value)
        {
            cl.UpdateName(value.ConsumerId, value.Name);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.DeleteConsumer(id);
        }

        [HttpGet("{id}/food")]
        public string GetMostOftenOrderedFoodByConsumer(int id)
        {
            return cl.MostOftenOrderedFoodByConsumer(id);
        }

        [HttpGet("{id}/restaurant")]
        public Restaurant GetMostOrdersFromRestaurantByConsumer(int id)
        {
            return cl.MostOrdersFromRestaurantByConsumer(id);
        }
    }
}
