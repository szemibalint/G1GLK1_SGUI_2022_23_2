using G1GLK1_HFT_2021221.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1GLK1_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly Delivery_service_context DeliveryServiceContext;

        public Repository(Delivery_service_context deliveryServiceContext)
        {
            DeliveryServiceContext = deliveryServiceContext;
        }

        public void Add(T entity)
        {
            DeliveryServiceContext.Set<T>().Add(entity);

            DeliveryServiceContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            DeliveryServiceContext.Set<T>().Remove(entity);

            DeliveryServiceContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return DeliveryServiceContext.Set<T>();
        }

        public abstract T GetOne(int id);

        public void Update(T entity)
        {
            DeliveryServiceContext.Set<T>().Attach(entity);

            DeliveryServiceContext.SaveChanges();
        }
    }
}
