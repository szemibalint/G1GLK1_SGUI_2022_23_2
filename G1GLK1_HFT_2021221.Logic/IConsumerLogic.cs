using G1GLK1_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Logic
{
    public interface IConsumerLogic
    {
        public void CreateConsumer(Consumer consumer);

        public string GetConsumer(int consumerID);

        public List<Consumer> GetConsumers();

        public void DeleteConsumer(int consumerID);

        public void UpdateName(int consumerID, string name);
        public void UpdateAdress(int consumerID, string address);

        public string MostOftenOrderedFoodByConsumer(int consumerID);
        public string MostOrdersFromRestaurantByConsumer(int consumerID);


    }
}
