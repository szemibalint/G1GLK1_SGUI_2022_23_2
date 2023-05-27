using G1GLK1_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Logic
{
    public interface IRestaurantLogic
    {
        public void CreateRestaurant(Restaurant restaurant);

        public Restaurant GetRestaurant(int restaurantID);

        public List<Restaurant> GetRestaurants();

        public void DeleteRestaurant(int restaurantID);

        public void UpdateName(int restaurantID, string name);

        public void UpdateLocation(int restaurantID, string location);

        public void UpdateCuisine(int restaurantID, string cuisine);
        public string ConsumerWithMostOrders(); 
    }
}
