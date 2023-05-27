
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
    public class RestaurantController : ControllerBase
    {

        IRestaurantLogic rl;

        public RestaurantController(IRestaurantLogic rl)
        {
            this.rl = rl;
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
        public Consumer GetConsumerWithMostOrders()
        {
            return rl.ConsumerWithMostOrders();
        }


    }
}
