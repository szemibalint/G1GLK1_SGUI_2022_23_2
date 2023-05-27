using G1GLK1_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Logic
{
    public interface IOrderLogic 
    {
        public void CreateOrder(Order order);

        public Order GetOrder(int orderID);

        public List<Order> GetOrders();

        public void DeleteOrder(int orderID);

        public void UpdateOrder(int orderID, string food, int price);

        public string GetConsumerName(int orderID);
        public string GetConsumerAddress(int orderID);
    }
}
