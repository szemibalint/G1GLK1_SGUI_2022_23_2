using G1GLK1_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Client
{
    class MethodHelper
    {
        FoodDeliveryService foodDeliveryService = new FoodDeliveryService(@"http://localhost:5184/");

        public void ListConsumers()
        {
            List<Consumer> consumers = foodDeliveryService.Get<Consumer>("consumer");

            foreach (var c in consumers)
            {
                Console.WriteLine($"Consumer ID: {c.ConsumerId}");
                Console.WriteLine($"Name: {c.Name}");
                Console.WriteLine($"Address: {c.Address}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public void ListOrders()
        {
            List<Order> orders = foodDeliveryService.Get<Order>("order");

            foreach (var o in orders)
            {
                Console.WriteLine($"Order ID: {o.OrderId}");
                Console.WriteLine($"Date: {o.TimeOfOrder}");
                Console.WriteLine($"Food: {o.Food}");
                Console.WriteLine($"Price: {o.Price}");
                Console.WriteLine($"Consumer ID: {o.ConsumerId}");
                Console.WriteLine($"Restaurant ID: {o.RestaurantId}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public void ListRestaurants()
        {
            List<Restaurant> restaurants = foodDeliveryService.Get<Restaurant>("restaurant");

            foreach (var r in restaurants)
            {
                Console.WriteLine($"Restaurant ID: {r.RestaurantId}");
                Console.WriteLine($"name: {r.Name}");
                Console.WriteLine($"Location: {r.Location}");
                Console.WriteLine($"Cuisine: {r.Cuisine}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        public void GetConsumer() 
        {
            Console.Write("Give a Consumer ID: ");
            int id = int.Parse(Console.ReadLine());

            Consumer c = foodDeliveryService.GetSingle<Consumer>($"consumer/{id}");

            Console.WriteLine($"Consumer ID: {c.ConsumerId}");
            Console.WriteLine($"Name: {c.Name}");
            Console.WriteLine($"Address: {c.Address}");
            Console.ReadLine();
        }

        public void GetOrder() {

            Console.Write("Give a Order ID: ");
            int id = int.Parse(Console.ReadLine());

            Order o = foodDeliveryService.GetSingle<Order>($"order/{id}");

            Console.WriteLine($"Order ID: {o.OrderId}");
            Console.WriteLine($"Date: {o.TimeOfOrder}");
            Console.WriteLine($"Food: {o.Food}");
            Console.WriteLine($"Price: {o.Price}");
            Console.WriteLine($"Consumer ID: {o.ConsumerId}");
            Console.WriteLine($"Restaurant ID: {o.RestaurantId}");
            Console.ReadLine();
        }

        public void GetRestaurant() {
            Console.Write("Give a Restaurant ID: ");
            int id = int.Parse(Console.ReadLine());

            Restaurant r = foodDeliveryService.GetSingle<Restaurant>($"restaurant/{id}");

            Console.WriteLine($"Restaurant ID: {r.RestaurantId}");
            Console.WriteLine($"Name: {r.Name}");
            Console.WriteLine($"Location: {r.Location}");
            Console.WriteLine($"Cuisine: {r.Cuisine}");
            Console.ReadLine();
        }

        public void CreateConsumer() {

            Consumer consumer = new Consumer();

            Console.Write("Give the name of the Consumer: ");
            consumer.Name = Console.ReadLine();

            Console.Write("Give the address of the Consumer: ");
            consumer.Address = Console.ReadLine();

            foodDeliveryService.Post<Consumer>(consumer, "consumer");

            Console.WriteLine();
            Console.WriteLine("Consumer created!");
            Console.ReadLine();

        }

        public void CreateOrder() 
        {
            Order order = new Order();

            Console.Write("Give the Date (Valid format is YYYY-MM-DD): ");
            order.TimeOfOrder = DateTime.Parse(Console.ReadLine());

            Console.Write("Give the Food: ");
            order.Food = Console.ReadLine();

            Console.Write("Give the Price: ");
            order.Price = int.Parse(Console.ReadLine());

            Console.Write("Give the Consumer ID: ");
            order.ConsumerId = int.Parse(Console.ReadLine());

            Console.Write("Give the Restaurant ID: ");
            order.RestaurantId = int.Parse(Console.ReadLine());

            foodDeliveryService.Post<Order>(order, "order");

            Console.WriteLine();
            Console.WriteLine("Order created!");
            Console.ReadLine();
        }

        public void CreateRestaurant() 
        {
            Restaurant restaurant = new Restaurant();

            Console.Write("Give the Name: ");
            restaurant.Name = Console.ReadLine();

            Console.Write("Give the Location: ");
            restaurant.Location = Console.ReadLine();

            Console.Write("Give the Cuisine: ");
            restaurant.Cuisine= Console.ReadLine();

            foodDeliveryService.Post<Restaurant>(restaurant, "restaurant");

            Console.WriteLine();
            Console.WriteLine("Restaurant created!");
            Console.ReadLine();
        }

        public void UpdateConsumerName() 
        {
            Consumer consumer = new Consumer();

            Console.Write("Give the Consumer ID: ");
            consumer.ConsumerId = int.Parse(Console.ReadLine());

            Console.Write("Give the new Name you want to change to: ");
            consumer.Name = Console.ReadLine();

            foodDeliveryService.Put<Consumer>(consumer, "consumer/name");

            Console.WriteLine();
            Console.WriteLine("Consumer Updated!");
            Console.ReadLine();
        }

        public void UpdateConsumerAddress() 
        {
            Consumer consumer = new Consumer();

            Console.Write("Give the Consumer ID: ");
            consumer.ConsumerId = int.Parse(Console.ReadLine());

            Console.Write("Give the new Address you want to change to: ");
            consumer.Address = Console.ReadLine();

            foodDeliveryService.Put<Consumer>(consumer, "consumer/address");

            Console.WriteLine();
            Console.WriteLine("Consumer Updated!");
            Console.ReadLine();
        }

        public void UpdateOrder() 
        {
            Order order = new Order();

            Console.Write("Give the Order ID: ");
            order.OrderId = int.Parse(Console.ReadLine());

            Console.Write("Give the new Food you want to change to: ");
            order.Food = Console.ReadLine();

            Console.Write("Give the new Price: ");
            order.Price = int.Parse(Console.ReadLine());

            foodDeliveryService.Put<Order>(order, "order");

            Console.WriteLine();
            Console.WriteLine("Order Updated!");
            Console.ReadLine();
        }

        public void UpdateRestaurantName() 
        {
            Restaurant restaurant = new Restaurant();

            Console.Write("Give the Restaurant ID: ");
            restaurant.RestaurantId = int.Parse(Console.ReadLine());

            Console.Write("Give the new Name you want to change to; ");
            restaurant.Name = Console.ReadLine();

            foodDeliveryService.Put<Restaurant>(restaurant, "restaurant/name");

            Console.WriteLine();
            Console.WriteLine("Restaurant Updated!");
            Console.ReadLine();
        }

        public void UpdateRestaurantLocation() 
        {
            Restaurant restaurant = new Restaurant();

            Console.Write("Give the Restaurant ID: ");
            restaurant.RestaurantId = int.Parse(Console.ReadLine());

            Console.Write("Give the new Location you want to change to; ");
            restaurant.Location = Console.ReadLine();

            foodDeliveryService.Put<Restaurant>(restaurant, "restaurant/location");

            Console.WriteLine();
            Console.WriteLine("Restaurant Updated!");
            Console.ReadLine();
        }

        public void UpdateRestaurantCuisine() 
        {
            Restaurant restaurant = new Restaurant();

            Console.Write("Give the Restaurant ID: ");
            restaurant.RestaurantId = int.Parse(Console.ReadLine());

            Console.Write("Give the new Cuisine you want to change to; ");
            restaurant.Cuisine = Console.ReadLine();

            foodDeliveryService.Put<Restaurant>(restaurant, "restaurant/cuisine");

            Console.WriteLine();
            Console.WriteLine("Restaurant Updated!");
            Console.ReadLine();
        }

        public void DeleteConsumer() 
        {
            Console.Write("Give the Consumer ID: ");
            int id = int.Parse(Console.ReadLine());

            foodDeliveryService.Delete(id, $"consumer/{id}");

            Console.WriteLine();
            Console.WriteLine("Consumer deleted!");
            Console.ReadLine();
        }

        public void DeleteOrder() 
        {
            Console.Write("Give the Order ID: ");
            int id = int.Parse(Console.ReadLine());

            foodDeliveryService.Delete(id, $"order/{id}");

            Console.WriteLine();
            Console.WriteLine("Order deleted!");
            Console.ReadLine();
        }

        public void DeleteRestaurant() 
        {
            Console.Write("Give the Id of the Restaurant: ");
            int id = int.Parse(Console.ReadLine());

            foodDeliveryService.Delete(id, $"restaurant/{id}");

            Console.WriteLine();
            Console.WriteLine("Restaurant deleted!");
            Console.ReadLine();
        }

        public void GetMostOftenOrderedFoodByConsumer() 
        {
            Console.Write("Give the ID of the consumer");
            int id = int.Parse(Console.ReadLine());

           string food = foodDeliveryService.GetSingle<string>($"consumer/{id}/food");

            Console.WriteLine();
            Console.WriteLine($"The most ordered food id {food}!");
            Console.ReadLine();
        }

        public void GetMostOrdersFromRestaurantByConsumer() 
        {
            Console.Write("Give the ID of the consumer: ");
            int id = int.Parse(Console.ReadLine());

            Restaurant restaurant = foodDeliveryService.GetSingle<Restaurant>($"consumer/{id}/restaurant");

            Console.WriteLine();
            Console.WriteLine($"The most orders is from {restaurant.Name}!");
            Console.ReadLine();
        }

        public void GetConsumerNameOfOrder() 
        {
            Console.Write("Give the ID of the order: ");
            int id = int.Parse(Console.ReadLine());

            string name = foodDeliveryService.GetSingle<string>($"order/{id}/name");

            Console.WriteLine($"The name of the consumer who ordered this is {name}");
            Console.ReadLine();
        }

        public void GetConsumerAddressOfOrder() 
        {
            Console.Write("Give the ID of the order: ");
            int id = int.Parse(Console.ReadLine());

            string address = foodDeliveryService.GetSingle<string>($"order/{id}/address");

            Console.WriteLine($"The address of the consumer who ordered this is {address}");
            Console.ReadLine();
        }

        public void GetConsumerWithMostOrders() 
        {
            Consumer consumer = foodDeliveryService.GetSingle<Consumer>("restaurant/orders");

            Console.WriteLine("The consumer with most orders is: ");

            Console.WriteLine($"Consumer ID: {consumer.ConsumerId}");
            Console.WriteLine($"Name: {consumer.Name}");
            Console.WriteLine($"Address: {consumer.Address}");
            Console.ReadLine();
        }
    }
}
