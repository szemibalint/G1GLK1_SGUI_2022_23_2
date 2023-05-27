using G1GLK1_HFT_2021221.Models;
using G1GLK1_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Logic
{
    public class ConsumerLogic : IConsumerLogic
    {
        private readonly IConsumerRepository _consumerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public ConsumerLogic(IConsumerRepository consumerRepository,  IRestaurantRepository restaurantRepository, IOrderRepository orderRepository)
        {
            _consumerRepository = consumerRepository;
            _orderRepository = orderRepository;
            _restaurantRepository = restaurantRepository;
        }

        public void CreateConsumer(Consumer consumer)
        {
            _consumerRepository.Add(consumer);
        }

        public void DeleteConsumer(int consumerID)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            _consumerRepository.Delete(consumer);
        }

        public string GetConsumer(int consumerID)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            string consumerName = consumer.Name;
            return consumerName;
        }

        public List<Consumer> GetConsumers()
        {
            return _consumerRepository.GetAll().ToList();
        }

        public string MostOftenOrderedFoodByConsumer(int consumerID)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            List<Order> orders = _orderRepository.GetAll().Where(X => X.ConsumerId == consumer.ConsumerId).ToList();
            int biggestCount = 0;
            string food = "";
            foreach (var currentOrder in orders)
            {
                int count = 0;
                foreach(var order in orders)
                {
                    if (order.Food == currentOrder.Food)
                    {
                        count++;
                    }
                }
                if (count > biggestCount)
                {
                    biggestCount = count;
                    food = currentOrder.Food;
                }
            }
            return food;
        }

        public string MostOrdersFromRestaurantByConsumer(int consumerID)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            List<Order> orders = _orderRepository.GetAll().Where(x => x.ConsumerId == consumer.ConsumerId).ToList();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (var order in orders)
            {
                restaurants.Add(_restaurantRepository.GetOne(order.RestaurantId));
            }

            int biggestCount = 0;
            Restaurant mostUsedRestaurant = new Restaurant();
            string mostUsedRestaurantReturn = "";
            foreach (var currentRestaurant in restaurants)
            {
                int count = 0;
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.Name == currentRestaurant.Name)
                    {
                        count++;
                    }
                }
                if (count > biggestCount)
                {
                    biggestCount = count;
                    mostUsedRestaurant = currentRestaurant;
                }
            }
            mostUsedRestaurantReturn = mostUsedRestaurant.Name;
            return mostUsedRestaurantReturn;
        }

        public void UpdateAdress(int consumerID, string address)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            consumer.Address = address;

            _consumerRepository.Update(consumer);
        }

        public void UpdateName(int consumerID, string name)
        {
            Consumer consumer = _consumerRepository.GetOne(consumerID);
            if (consumer == null)
            {
                throw new Exception("consumer cannot be found");
            }
            consumer.Name = name;

            _consumerRepository.Update(consumer);

        }
    }
}
