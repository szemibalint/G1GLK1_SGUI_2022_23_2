using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using G1GLK1_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using G1GLK1_SGUI_2023_23_2.WpfClient;
using System.Numerics;
using System.Windows.Threading;
using System.Security.Policy;
using System.Runtime.InteropServices;

namespace G1GLK1_SGUI_2023_23_2.WPFClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        //RESTCOLLECTIONS
        public RestCollection<Consumer> Consumers { get; set; }
        public RestCollection<Order> Orders { get; set; }

        public RestCollection<Restaurant> Restaurants { get; set; }

        public RestService RestService { get; set; }

        //CONSUMER

        private Consumer selectedConsumer;

        public Consumer SelectedConsumer
        {
            get { return selectedConsumer; }
            set
            {
                if (value != null)
                {
                    selectedConsumer = new Consumer()
                    {
                        Name = value.Name,
                        Address = value.Address,
                        ConsumerId = value.ConsumerId,
                    };
                    OnPropertyChanged();
                    (DeleteConsumerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private string mostOftenOrderedFood;

        public string MostOftenOrderedFood
        {
            get { return mostOftenOrderedFood; }

            set {
                if (value != null)
                {
                    mostOftenOrderedFood = value;
                    OnPropertyChanged();
                    (GetMostOftenOrderedFoodFromCustomer as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private string mostOrdersFromRestaurantByConsumer;

        public string MostOrdersFromRestaurantByConsumer
        {
            get { return mostOrdersFromRestaurantByConsumer; }

            set {
                if (value != null)
                {
                    mostOrdersFromRestaurantByConsumer = value;
                    OnPropertyChanged();
                    (GetMostOrdersFromRestaurantByConsumer as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }



        public ICommand CreateConsumerCommand { get; set; }
        public ICommand DeleteConsumerCommand { get; set; }
        public ICommand UpdateConsumerNameCommand { get; set; }
        public ICommand UpdateConsumerAddressCommand { get; set; }
        public ICommand GetMostOftenOrderedFoodFromCustomer { get; set; }
        public ICommand GetMostOrdersFromRestaurantByConsumer { get; set; }

        //ORDER

        private Order selectedOrder;

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                if (value != null)
                {
                    selectedOrder = new Order()
                    {
                        TimeOfOrder = value.TimeOfOrder,
                        Food = value.Food,
                        Price = value.Price,
                        RestaurantId = value.RestaurantId,
                        ConsumerId = value.ConsumerId,
                        OrderId = value.OrderId,
                    };
                    OnPropertyChanged();
                    (DeleteOrderCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private string consumerName;

        public string ConsumerName
        {
            get { return consumerName; }
            set {
                if (value != null)
                {
                    consumerName = value;
                    OnPropertyChanged();
                    (GetConsumerNameFromOrder as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private string consumerAddress;

        public string ConsumerAddress
        {
            get { return consumerAddress; }
            set {
                if (value != null)
                {
                    consumerAddress = value;
                    OnPropertyChanged();
                    (GetConsumerAddressFromOrder as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }



        public ICommand CreateOrderCommand { get; set; }
        public ICommand DeleteOrderCommand { get; set; }
        public ICommand UpdateOrderCommand { get; set; }

        public ICommand GetConsumerNameFromOrder { get; set; }

        public ICommand GetConsumerAddressFromOrder { get; set; }

        //RESTAURANT

        private Restaurant selectedRestaurant;

        public Restaurant SelectedRestaurant
        {
            get { return selectedRestaurant; }
            set
            {
                if (value != null)
                {
                    selectedRestaurant = new Restaurant()
                    {
                        Name = value.Name,
                        Cuisine = value.Cuisine,
                        Location = value.Location,
                        RestaurantId = value.RestaurantId,
                    };
                    OnPropertyChanged();
                    (DeleteRestaurantCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private string consumerWithMostOrders;

        public string ConsumerWithMostOrders
        {
            get { return consumerWithMostOrders; }
            set {
                if (value != null)
                {
                    consumerWithMostOrders = value;
                    OnPropertyChanged();
                    (GetConsumerWithMostOrders as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateRestaurantCommand { get; set; }
        public ICommand DeleteRestaurantCommand { get; set; }
        public ICommand UpdateRestaurantNameCommand { get; set; }
        public ICommand UpdateRestaurantLocationCommand { get; set; }
        public ICommand UpdateRestaurantCuisineCommand { get; set; }

        public ICommand GetConsumerWithMostOrders { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Consumers = new RestCollection<Consumer>("http://localhost:5184/", "consumer");
                Orders = new RestCollection<Order>("http://localhost:5184/", "order");
                Restaurants = new RestCollection<Restaurant>("http://localhost:5184/", "restaurant");

                RestService = new("http://localhost:5184/");


                //CONSUMER CRUD 

                CreateConsumerCommand = new RelayCommand(() =>
                {


                    Consumers.Add(new Consumer()
                    {
                        Name = SelectedConsumer.Name,
                        Address = SelectedConsumer.Address,
                    });
                });

                UpdateConsumerNameCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Consumers.Update(SelectedConsumer, "name");
                        OnPropertyChanged(nameof(SelectedConsumer));
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                UpdateConsumerAddressCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Consumers.Update(SelectedConsumer, "address");
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteConsumerCommand = new RelayCommand(() =>
                {
                    Consumers.Delete(SelectedConsumer.ConsumerId);
                },
                () =>
                {
                    return SelectedConsumer != null;
                });
                SelectedConsumer = new Consumer();

                //CONSUMER NON CRUD

                GetMostOftenOrderedFoodFromCustomer = new RelayCommand(() =>
                {
                    MostOftenOrderedFood = Consumers.GetMostOftenOrderedFoodFromCustomer(selectedConsumer.ConsumerId);
                });

                GetMostOrdersFromRestaurantByConsumer = new RelayCommand(() =>
                {
                    MostOrdersFromRestaurantByConsumer = Consumers.GetMostOrdersFromRestaurantByConsumer(selectedConsumer.ConsumerId);
                });



                //ORDER CRUD

                CreateOrderCommand = new RelayCommand(() =>
                {


                    Orders.Add(new Order()
                    {
                        TimeOfOrder = SelectedOrder.TimeOfOrder,
                        Price = SelectedOrder.Price,
                        Food = SelectedOrder.Food,
                        RestaurantId = SelectedOrder.RestaurantId,
                        ConsumerId = SelectedOrder.ConsumerId,
                    });
                });

                UpdateOrderCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Orders.Update(SelectedOrder);
                        OnPropertyChanged(nameof(SelectedOrder));
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteOrderCommand = new RelayCommand(() =>
                {
                    Orders.Delete(SelectedOrder.OrderId);
                },
                () =>
                {
                    return SelectedOrder != null;
                });
                SelectedOrder = new Order();

                //ORDER NON CRUD

                GetConsumerNameFromOrder = new RelayCommand(() =>
                {
                    ConsumerName = Orders.GetConsumerNameFromOrder(selectedOrder.OrderId);
                });

                GetConsumerAddressFromOrder = new RelayCommand(() =>
                {
                    ConsumerAddress = Orders.GetConsumerAddressFromOrder(selectedOrder.OrderId);
                });

                //RESTAURANT CRUD

                CreateRestaurantCommand = new RelayCommand(() =>
                {


                    Restaurants.Add(new Restaurant()
                    {
                        Name = SelectedRestaurant.Name,
                        Cuisine = SelectedRestaurant.Cuisine,
                        Location = SelectedRestaurant.Location,
                    });
                });

                UpdateRestaurantNameCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Restaurants.Update(SelectedRestaurant, "name");
                        OnPropertyChanged(nameof(SelectedRestaurant));
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                UpdateRestaurantLocationCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Restaurants.Update(SelectedRestaurant, "location");
                        OnPropertyChanged(nameof(SelectedRestaurant));
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                UpdateRestaurantCuisineCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Restaurants.Update(SelectedRestaurant, "cuisine");
                        OnPropertyChanged(nameof(SelectedRestaurant));
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });


                DeleteRestaurantCommand = new RelayCommand(() =>
                {
                    Restaurants.Delete(SelectedRestaurant.RestaurantId);
                },
                () =>
                {
                    return SelectedRestaurant != null;
                });
                SelectedRestaurant = new Restaurant();

                //RESTAURANT NON CRUD

                GetConsumerWithMostOrders = new RelayCommand(() =>
                {
                    ConsumerWithMostOrders = Orders.GetConsumerWithMostOrders();
                });

            }

        }
    }
}
