using G1GLK1_HFT_2021221.Models;
using G1GLK1_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Logic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IConsumerRepository _consumerRepository;

        public OrderLogic(IOrderRepository orderRepository, IConsumerRepository consumerRepository)
        {
            _orderRepository = orderRepository;
            _consumerRepository = consumerRepository;
        }

        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);       
        }

        public void DeleteOrder(int orderID)
        {
            Order order = _orderRepository.GetOne(orderID);
            if (order == null)
            {
                throw new Exception("order cannot be found!");
            }
            _orderRepository.Delete(order);
        }

        public string GetConsumerAddress(int orderID)
        {
            Order order = _orderRepository.GetOne(orderID);
            if (order == null)
            {
                throw new Exception("order cannot be found!");
            }

            Consumer consumer = _consumerRepository.GetOne(order.ConsumerId);

            return consumer.Address;
        }

        public string GetConsumerName(int orderID)
        {
            Order order = _orderRepository.GetOne(orderID);
            if (order == null)
            {
                throw new Exception("order cannot be found!");
            }

            Consumer consumer = _consumerRepository.GetOne(order.ConsumerId);

            return consumer.Name;
        }

        public Order GetOrder(int orderID)
        {
            Order order = _orderRepository.GetOne(orderID);
            if (order == null)
            {
                throw new Exception("order cannot be found!");
            }
            return order;
        }

        public List<Order> GetOrders()
        {
            return _orderRepository.GetAll().ToList();
        }

        public void UpdateOrder(int orderID, string food, int price)
        {
            Order order = _orderRepository.GetOne(orderID);
            if (order == null)
            {
                throw new Exception("order cannot be found!");
            }
            order.Food = food;
            order.Price = price;
            _orderRepository.Update(order);
        }
    }
}
