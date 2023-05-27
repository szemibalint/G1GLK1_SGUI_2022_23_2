using ConsoleTools;
using System;

namespace G1GLK1_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodHelper methodHelper = new MethodHelper();

            var listMenu = new ConsoleMenu(args, level: 1)
       .Add("List Consumers", () => methodHelper.ListConsumers())
       .Add("List Orders", () => methodHelper.ListOrders())
       .Add("List Restaurants", () => methodHelper.ListRestaurants())
       .Add("Return", ConsoleMenu.Close)
       .Configure(config =>
       {
           config.Selector = "--> ";
           config.EnableFilter = true;
           config.Title = "List Menu";
           config.EnableBreadcrumb = true;
           config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
       });

            var getMenu = new ConsoleMenu(args, level: 1)
       .Add("Get Consumer", () => methodHelper.GetConsumer())
       .Add("Get Order", () => methodHelper.GetOrder())
       .Add("Get Restaurant", () =>methodHelper.GetRestaurant())
       .Add("Return", ConsoleMenu.Close)
      .Configure(config =>
      {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "Get Menu";
          config.EnableBreadcrumb = true;
          config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
      });

            var createMenu = new ConsoleMenu(args, level: 1)
       .Add("Create Consumer", () => methodHelper.CreateConsumer())
       .Add("Create Order", () => methodHelper.CreateOrder())
       .Add("Create Restaurant", () => methodHelper.CreateRestaurant())
       .Add("Return", ConsoleMenu.Close)
      .Configure(config =>
      {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "Create Menu";
          config.EnableBreadcrumb = true;
          config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
      });

            var updateMenu = new ConsoleMenu(args, level: 1)
       .Add("Update Consumer Name", () => methodHelper.UpdateConsumerName())
       .Add("Update Consumer Address", () => methodHelper.UpdateConsumerAddress())
       .Add("Update Order", () => methodHelper.UpdateOrder())
       .Add("Update Restaurant Name", () => methodHelper.UpdateRestaurantName())
       .Add("Update Restaurant Location", () => methodHelper.UpdateRestaurantLocation())
       .Add("Update Restaurant Cuisine", () => methodHelper.UpdateRestaurantCuisine())
       .Add("Return", ConsoleMenu.Close)
      .Configure(config =>
      {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "Update Menu";
          config.EnableBreadcrumb = true;
          config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
      });

            var deleteMenu = new ConsoleMenu(args, level: 1)
       .Add("Delete Consumer", () => methodHelper.DeleteConsumer())
       .Add("Delete Order", () => methodHelper.DeleteOrder())
       .Add("Delete Restaurant", () => methodHelper.DeleteRestaurant())
       .Add("Return", ConsoleMenu.Close)
      .Configure(config =>
      {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "Delete Menu";
          config.EnableBreadcrumb = true;
          config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
      });

            var nonCRUDMenu = new ConsoleMenu(args, level: 1)
      .Add("Get Most Often Ordered Food By Consumer", () => methodHelper.GetMostOftenOrderedFoodByConsumer())
      .Add("Get Most Orders From Restaurant By Consumer", () => methodHelper.GetMostOrdersFromRestaurantByConsumer())
      .Add("Get Consumer Name Of Order", () => methodHelper.GetConsumerNameOfOrder())
      .Add("Get Consumer Address Of Order", () => methodHelper.GetConsumerAddressOfOrder())
      .Add("Get Consumer With Most Orders", () => methodHelper.GetConsumerWithMostOrders())
      .Add("Sub_Close", ConsoleMenu.Close)
      .Configure(config =>
      {
          config.Selector = "--> ";
          config.EnableFilter = true;
          config.Title = "non-CRUD Menu";
          config.EnableBreadcrumb = true;
          config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
      });

            var menu = new ConsoleMenu(args, level: 0)
              .Add("List", listMenu.Show)
              .Add("Get", getMenu.Show)
              .Add("Create", createMenu.Show)
              .Add("Update", updateMenu.Show)
              .Add("Delete", deleteMenu.Show)
              .Add("non-CRUD",nonCRUDMenu.Show)
              .Add("Exit", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = true;
                  config.Title = "Main menu";
                  config.EnableWriteTitle = true;
                  config.EnableBreadcrumb = true;
              });

            menu.Show();
        }

        private static void SomeAction(string v)
        {
        }
    }
}
