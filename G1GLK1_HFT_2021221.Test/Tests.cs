using G1GLK1_HFT_2021221.Logic;
using G1GLK1_HFT_2021221.Models;
using G1GLK1_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G1GLK1_HFT_2021221.Test
{
    [TestFixture]
    public class Tests
    {
        private ConsumerLogic consumerLogic { get; set; }
        private OrderLogic orderLogic { get; set; }
        private RestaurantLogic restaurantLogic { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<IConsumerRepository> mockedConsRepo = new Mock<IConsumerRepository>();
            Mock<IOrderRepository> mockedOrdRepo = new Mock<IOrderRepository>();
            Mock<IRestaurantRepository> mockedResRepo = new Mock<IRestaurantRepository>();

            List<Consumer> consumers = this.FakeConsumerObjects().ToList();
            int counter = 1;
            foreach (var consumer in consumers)
            {
                mockedConsRepo.Setup(x => x.GetOne(counter)).Returns(consumer);
                counter++;
            }

            List<Restaurant> restaurants = this.FakeRestaurantObjects().ToList();
            int counter1 = 1;
            foreach (var restaurant in restaurants)
            {
                mockedResRepo.Setup(x => x.GetOne(counter1)).Returns(restaurant);
                counter1++;
            }

            List<Order> orders = this.FakeOrderObjects().ToList();
            int counter2 = 1;
            foreach (var order in orders)
            {
                mockedOrdRepo.Setup(x => x.GetOne(counter2)).Returns(order);
                counter2++;
            }

            mockedOrdRepo.Setup(x => x.GetAll()).Returns(this.FakeOrderObjects());
            mockedConsRepo.Setup(x => x.GetAll()).Returns(this.FakeConsumerObjects());
            mockedResRepo.Setup(x => x.GetAll()).Returns(this.FakeRestaurantObjects());

            this.orderLogic = new OrderLogic(mockedOrdRepo.Object, mockedConsRepo.Object);
            this.consumerLogic = new ConsumerLogic(mockedConsRepo.Object, mockedResRepo.Object, mockedOrdRepo.Object);
            this.restaurantLogic = new RestaurantLogic(mockedResRepo.Object, mockedConsRepo.Object, mockedOrdRepo.Object);
        }

        [Test]
        public void GetConsumerName_Test()
        {
            var consumerName = orderLogic.GetConsumerName(1);

            Assert.That(consumerName.Equals("Stephen Currry"));
        }

        [Test]
        public void GetConsumerName_Throws()
        {

            Assert.Throws<Exception>(()=>orderLogic.GetConsumerName(7));
        }

        [Test]
        public void GetAdress_Test()
        {
            var address = orderLogic.GetConsumerAddress(1);
            Assert.That(address.Equals("MVP Street 30"));
        }

        [Test]
        public void GetConsumerAddress_Throws()
        {

            Assert.Throws<Exception>(() => orderLogic.GetConsumerAddress(7));
        }

        [Test]
        public void GetOrder_Test()
        {
            var order = orderLogic.GetOrder(1);
            Assert.That(order.OrderId.Equals(1));
        }

        [Test]
        public void ConsumerWithMostOrders_Test()
        {
            var consumerWithMostOrders = restaurantLogic.ConsumerWithMostOrders();
            Assert.That(consumerWithMostOrders.ConsumerId.Equals(3));
        }

        [Test]
        public void MostOftenOrderedFood_Test()
        {
            var mostOtenOrderedFoodByConsumer = consumerLogic.MostOftenOrderedFoodByConsumer(3);
            Assert.That(mostOtenOrderedFoodByConsumer.Equals("kobe Steak"));
        }

        [Test]
        public void MostOftenOrderedFood_Throws()
        {
            Assert.Throws<Exception>(() => consumerLogic.MostOftenOrderedFoodByConsumer(4));
        }

        [Test]
        public void MostOrdersFromRestaurantByConsumer_Test()
        {
            var mostOrdersFromRestaurantByConsumer = consumerLogic.MostOrdersFromRestaurantByConsumer(3);

            Assert.That(mostOrdersFromRestaurantByConsumer.RestaurantId.Equals(2));
        }

        [Test]
        public void MostOrdersFromRestaurantByConsumer_Throws()
        {
            Assert.Throws<Exception>(() => consumerLogic.MostOrdersFromRestaurantByConsumer(4));
        }


        private IQueryable<Order> FakeOrderObjects()
        {
            Order o0 = new Order() { OrderId = 1, TimeOfOrder = new DateTime(2021, 11, 21, 17, 23, 00), Food = "Pasta Carbonara", Price = 1980, ConsumerId = 1, RestaurantId = 1 };
            Order o1 = new Order() { OrderId = 2, TimeOfOrder = new DateTime(2021, 11, 16, 20, 23, 00), Food = "Pizza Bolognese", Price = 2100, ConsumerId = 2, RestaurantId = 1 };
            Order o2 = new Order() { OrderId = 3, TimeOfOrder = new DateTime(2021, 11, 12, 8, 23, 00), Food = "Pasta Pomodoro", Price = 1780, ConsumerId = 2, RestaurantId = 1 };
            Order o3 = new Order() { OrderId = 4, TimeOfOrder = new DateTime(2021, 11, 10, 16, 23, 00), Food = "T-bone Steak", Price = 6760, ConsumerId = 3, RestaurantId = 2 };
            Order o4 = new Order() { OrderId = 5, TimeOfOrder = new DateTime(2021, 11, 20, 17, 22, 00), Food = "kobe Steak", Price = 120000, ConsumerId = 3, RestaurantId = 2 };
            Order o5 = new Order() { OrderId = 6, TimeOfOrder = new DateTime(2021, 11, 20, 17, 22, 00), Food = "kobe Steak", Price = 120000, ConsumerId = 3, RestaurantId = 2 };

            Restaurant r0 = new Restaurant() { RestaurantId = 1, Name = "Steak House", Location = "Kálvin Square", Cuisine = "American" };
            Restaurant r1 = new Restaurant() { RestaurantId = 2, Name = "Taste Of Italy", Location = "Bocskai Street", Cuisine = "Italian" };


            Consumer c0 = new Consumer() { ConsumerId = 1, Name = "Stephen Currry", Address = "MVP Street 30" };
            Consumer c1 = new Consumer() { ConsumerId = 2, Name = "Lando Norris", Address = "Drivers Street 4" };
            Consumer c2 = new Consumer() { ConsumerId = 3, Name = "Lebron James", Address = "Street of kings 23" };


            o0.Consumer = c0;
            o0.Restaurant = r0;
            o1.Consumer = c1;
            o1.Restaurant = r0;
            o2.Consumer = c1;
            o2.Restaurant = r0;
            o3.Consumer = c2;
            o3.Restaurant = r1;
            o4.Consumer = c2;
            o4.Restaurant = r1;
            o5.Consumer = c2;
            o5.Restaurant = r1;


            List<Order> items = new List<Order>();
            items.Add(o0);
            items.Add(o1);
            items.Add(o2);
            items.Add(o3);
            items.Add(o4);
            items.Add(o5);

            return items.AsQueryable();
        }
        private IQueryable<Consumer> FakeConsumerObjects()
        {
            Order o0 = new Order() { OrderId = 1, TimeOfOrder = new DateTime(2021, 11, 21, 17, 23, 00), Food = "Pasta Carbonara", Price = 1980, ConsumerId = 1, RestaurantId = 1 };
            Order o1 = new Order() { OrderId = 2, TimeOfOrder = new DateTime(2021, 11, 16, 20, 23, 00), Food = "Pizza Bolognese", Price = 2100, ConsumerId = 2, RestaurantId = 1 };
            Order o2 = new Order() { OrderId = 3, TimeOfOrder = new DateTime(2021, 11, 12, 8, 23, 00), Food = "Pasta Pomodoro", Price = 1780, ConsumerId = 2, RestaurantId = 1 };
            Order o3 = new Order() { OrderId = 4, TimeOfOrder = new DateTime(2021, 11, 10, 16, 23, 00), Food = "T-bone Steak", Price = 6760, ConsumerId = 3, RestaurantId = 2 };
            Order o4 = new Order() { OrderId = 5, TimeOfOrder = new DateTime(2021, 11, 20, 17, 22, 00), Food = "Cheeseburger", Price = 2270, ConsumerId = 3, RestaurantId = 2 };
            Order o5 = new Order() { OrderId = 5, TimeOfOrder = new DateTime(2021, 11, 20, 17, 22, 00), Food = "kobe Steak", Price = 120000, ConsumerId = 3, RestaurantId = 2 };

            Restaurant r0 = new Restaurant() { RestaurantId = 1, Name = "Steak House", Location = "Kálvin Square", Cuisine = "American" };
            Restaurant r1 = new Restaurant() { RestaurantId = 2, Name = "Taste Of Italy", Location = "Bocskai Street", Cuisine = "Italian" };


            Consumer c0 = new Consumer() { ConsumerId = 1, Name = "Stephen Currry", Address = "MVP Street 30" };
            Consumer c1 = new Consumer() { ConsumerId = 2, Name = "Lando Norris", Address = "Drivers Street 4" };
            Consumer c2 = new Consumer() { ConsumerId = 3, Name = "Lebron James", Address = "Street of kings 23" };


            o0.Consumer = c0;
            o0.Restaurant = r0;
            o1.Consumer = c1;
            o1.Restaurant = r0;
            o2.Consumer = c1;
            o2.Restaurant = r0;
            o3.Consumer = c2;
            o3.Restaurant = r1;
            o4.Consumer = c2;
            o4.Restaurant = r1;
            o5.Consumer = c2;
            o5.Restaurant = r1;


            List<Consumer> items = new List<Consumer>();
            items.Add(c0);
            items.Add(c1);
            items.Add(c2);

            return items.AsQueryable();
        }
        private IQueryable<Restaurant> FakeRestaurantObjects()
        {
            Order o0 = new Order() { OrderId = 1, TimeOfOrder = new DateTime(2021, 11, 21, 17, 23, 00), Food = "Pasta Carbonara", Price = 1980, ConsumerId = 1, RestaurantId = 1 };
            Order o1 = new Order() { OrderId = 2, TimeOfOrder = new DateTime(2021, 11, 16, 20, 23, 00), Food = "Pizza Bolognese", Price = 2100, ConsumerId = 2, RestaurantId = 1 };
            Order o2 = new Order() { OrderId = 3, TimeOfOrder = new DateTime(2021, 11, 12, 8, 23, 00), Food = "Pasta Pomodoro", Price = 1780, ConsumerId = 2, RestaurantId = 1 };
            Order o3 = new Order() { OrderId = 4, TimeOfOrder = new DateTime(2021, 11, 10, 16, 23, 00), Food = "T-bone Steak", Price = 6760, ConsumerId = 3, RestaurantId = 2 };
            Order o4 = new Order() { OrderId = 5, TimeOfOrder = new DateTime(2021, 11, 20, 17, 22, 00), Food = "Cheeseburger", Price = 2270, ConsumerId = 3, RestaurantId = 2 };
            Order o5 = new Order() { OrderId = 5, TimeOfOrder = new DateTime(2021, 11, 20, 17, 22, 00), Food = "kobe Steak", Price = 120000, ConsumerId = 3, RestaurantId = 2 };

            Restaurant r0 = new Restaurant() { RestaurantId = 1, Name = "Steak House", Location = "Kálvin Square", Cuisine = "American" };
            Restaurant r1 = new Restaurant() { RestaurantId = 2, Name = "Taste Of Italy", Location = "Bocskai Street", Cuisine = "Italian" };


            Consumer c0 = new Consumer() { ConsumerId = 1, Name = "Stephen Currry", Address = "MVP Street 30" };
            Consumer c1 = new Consumer() { ConsumerId = 2, Name = "Lando Norris", Address = "Drivers Street 4" };
            Consumer c2 = new Consumer() { ConsumerId = 3, Name = "Lebron James", Address = "Street of kings 23" };


            o0.Consumer = c0;
            o0.Restaurant = r0;
            o1.Consumer = c1;
            o1.Restaurant = r0;
            o2.Consumer = c1;
            o2.Restaurant = r0;
            o3.Consumer = c2;
            o3.Restaurant = r1;
            o4.Consumer = c2;
            o4.Restaurant = r1;
            o5.Consumer = c2;
            o5.Restaurant = r1;


            List<Restaurant> items = new List<Restaurant>();
            items.Add(r0);
            items.Add(r1);

            return items.AsQueryable();
        }
    }
}
