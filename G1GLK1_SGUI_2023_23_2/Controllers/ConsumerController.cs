
using G1GLK1_HFT_2021221.Logic;
using G1GLK1_HFT_2021221.Models;
using G1GLK1_SGUI_2023_23_2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
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
        IHubContext<SignalR> hub;

        public ConsumerController(IConsumerLogic cl, IHubContext<SignalR> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Consumer> Get()
        {
            return cl.GetConsumers();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return cl.GetConsumer(id);
        }

        [HttpPost]
        public void Post([FromBody] Consumer value)
        {
            cl.CreateConsumer(value);
            this.hub.Clients.All.SendAsync("ConsumerCreated", value);
        }

        [HttpPut("address")]
        public void PutAddress([FromBody] Consumer value)
        {
            cl.UpdateAdress(value.ConsumerId, value.Address);
            this.hub.Clients.All.SendAsync("ConsumerCreated", value);
        }

        [HttpPut("name")]
        public void PutName([FromBody] Consumer value)
        {
            cl.UpdateName(value.ConsumerId, value.Name);
            this.hub.Clients.All.SendAsync("ConsumerCreated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var consumerToDelete = this.cl.GetConsumer(id);
            cl.DeleteConsumer(id);
            this.hub.Clients.All.SendAsync("ConsumerCreated", consumerToDelete);
        }

        [HttpGet("{id}/food")]
        public string GetMostOftenOrderedFoodByConsumer(int id)
        {
            return cl.MostOftenOrderedFoodByConsumer(id);
        }

        [HttpGet("{id}/restaurant")]
        public string GetMostOrdersFromRestaurantByConsumer(int id)
        {
            return cl.MostOrdersFromRestaurantByConsumer(id);
        }
    }
}
