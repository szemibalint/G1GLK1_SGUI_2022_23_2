using G1GLK1_HFT_2021221.Data;
using G1GLK1_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(Delivery_service_context deliveryServiceContext) : base(deliveryServiceContext)
        {

        }
        public override Order GetOne(int id)
        {
            return DeliveryServiceContext
                .Orders
                .SingleOrDefault(courier => courier.OrderId == id);
        }
    }
}
