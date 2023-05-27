using G1GLK1_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Data
{
    public class Delivery_service_context : DbContext
    {
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public Delivery_service_context()
        {
            Database.EnsureCreated();
        }
        public Delivery_service_context(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True; MultipleActiveResultSets=True;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasData(new Restaurant { RestaurantId = 1, Location = "Raday  Street" , Cuisine = "Chinese" , Name = "Best 'Chicken' in Town"});
            modelBuilder.Entity<Restaurant>()
                .HasData(new Restaurant { RestaurantId = 2, Location = "Kalocsai  Street", Cuisine = "Italian", Name = "Pasta all the way" });
            modelBuilder.Entity<Restaurant>()
                .HasData(new Restaurant { RestaurantId = 3, Location = "Break  Street", Cuisine = "American", Name = "Not Junk Food" });
            modelBuilder.Entity<Restaurant>()
                .HasData(new Restaurant { RestaurantId = 4, Location = "High  Hills", Cuisine = "International", Name = "Come Here We give you Anything" });
            modelBuilder.Entity<Restaurant>()
                .HasData(new Restaurant { RestaurantId = 5, Location = "Cobblestone Square", Cuisine = "Thai", Name = "Thai pastas" });
            
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 1,  ConsumerId = 1 , RestaurantId = 1,  Food = "Chicken Curry with rice" , Price = 1769, TimeOfOrder = new DateTime(2021,11,14,16,23,00)});
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 2, ConsumerId = 1, RestaurantId = 1, Food = "Chinse Menu for 2", Price = 4267, TimeOfOrder = new DateTime(2021, 8, 12, 14, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 3, ConsumerId = 2, RestaurantId = 1, Food = "Chicken Curry with rice", Price = 1769, TimeOfOrder = new DateTime(2021, 7, 14, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 4, ConsumerId = 2, RestaurantId = 3, Food = "Philly sandwich", Price = 3347, TimeOfOrder = new DateTime(2021, 8, 11, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 5, ConsumerId = 3, RestaurantId = 4, Food = "Four Seasons Pizza (32cm)", Price = 2270, TimeOfOrder = new DateTime(2021, 11, 2, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 6, ConsumerId = 3, RestaurantId = 5, Food = "Thai Sweets", Price = 1680, TimeOfOrder = new DateTime(2021, 3, 14, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 7, ConsumerId = 3, RestaurantId = 5, Food = "Pad Thai", Price = 2450, TimeOfOrder = new DateTime(2021, 11, 14, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 8, ConsumerId = 4, RestaurantId = 3, Food = "CheeseBurger", Price = 2780, TimeOfOrder = new DateTime(2021, 1, 14, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 9, ConsumerId = 4, RestaurantId = 2, Food = "Pasta Bolognese", Price = 2130, TimeOfOrder = new DateTime(2021, 2, 11, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 10, ConsumerId = 4, RestaurantId = 2, Food = "Pasta Pomodor", Price = 1540, TimeOfOrder = new DateTime(2021, 11, 4, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 11, ConsumerId = 4, RestaurantId = 4, Food = "Beef Stew", Price = 3265, TimeOfOrder = new DateTime(2021, 3, 14, 16, 23, 00) });
            modelBuilder.Entity<Order>()
                .HasData(new Order { OrderId = 12, ConsumerId = 5, RestaurantId = 2, Food = "Pasta Carbonara", Price = 1980, TimeOfOrder = new DateTime(2021, 11, 30, 11, 30, 00) });

            modelBuilder.Entity<Consumer>()
                .HasData(new Consumer { ConsumerId = 1 , Name = "Rock Lee" , Address = "Kossuth Square 45"});
            modelBuilder.Entity<Consumer>()
                .HasData(new Consumer { ConsumerId = 2, Name = "Max Verstappen", Address = "Dutch way 59" });
            modelBuilder.Entity<Consumer>()
                .HasData(new Consumer { ConsumerId = 3, Name = "Stephen Curry", Address = "MVP's Street 30" });
            modelBuilder.Entity<Consumer>()
                .HasData(new Consumer { ConsumerId = 4, Name = "John Wick", Address = "Beast Hills 87/a" });
            modelBuilder.Entity<Consumer>()
                .HasData(new Consumer { ConsumerId = 5, Name = "Bruce Willis", Address = "Saviour way 69" });
        }
    }
}
