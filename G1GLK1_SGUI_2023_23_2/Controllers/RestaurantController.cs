
using G1GLK1_HFT_2021221.Logic;
using G1GLK1_HFT_2021221.Models;
using G1GLK1_SGUI_2023_23_2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace G1GLK1_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        IRestaurantLogic rl;
        IHubContext<SignalR> hub;

        public RestaurantController(IRestaurantLogic rl, IHubContext<SignalR> hub)
        {
            this.rl = rl;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return rl.GetRestaurants();
        }

        [HttpGet("{id}")]
        public Restaurant Get(int id)
        {
            return rl.GetRestaurant(id);
        }

        [HttpPost]
        public void Post([FromBody] Restaurant value)
        {
            rl.CreateRestaurant(value);
        }

        [HttpPut("name")]
        public void PutName([FromBody] Restaurant value)
        {
            rl.UpdateName(value.RestaurantId, value.Name);
        }

        [HttpPut("location")]
        public void PutLocation([FromBody] Restaurant value)
        {
            rl.UpdateLocation(value.RestaurantId, value.Location);
        }

        [HttpPut("cuisine")]
        public void PutCuisine([FromBody] Restaurant value)
        {
            rl.UpdateCuisine(value.RestaurantId, value.Cuisine);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rl.DeleteRestaurant(id);
        }

        [HttpGet("orders")]
        public string GetConsumerWithMostOrders()
        {
            return rl.ConsumerWithMostOrders();
        }


    }
}
