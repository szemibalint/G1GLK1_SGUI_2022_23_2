using G1GLK1_HFT_2021221.Data;
using G1GLK1_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Repository
{
    public class ConsumerRepository : Repository<Consumer>, IConsumerRepository
    {
        public ConsumerRepository(Delivery_service_context deliveryServiceContext) : base(deliveryServiceContext)
        {
        }
        public override Consumer GetOne(int id)
        {
            return DeliveryServiceContext
                   .Consumers
                   .SingleOrDefault(consumer => consumer.ConsumerId == id);
        }
    }
}
