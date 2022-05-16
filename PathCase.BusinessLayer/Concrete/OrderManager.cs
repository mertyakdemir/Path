using PathCase.BusinessLayer.Abstract;
using PathCase.DataLayer.Abstract;
using PathCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.BusinessLayer.Concrete
{
    public class OrderManager : IOrderBusiness
    {
        private IOrderRepository orderRepository;

        public OrderManager(IOrderRepository _orderRepository)
        {
            orderRepository = _orderRepository;
        }

        public void Create(Order entity)
        {
            orderRepository.Create(entity);
        }

        public Order GetOrder(int orderId)
        {
            return orderRepository.GetOrder(orderId);
        }

        public List<Order> GetOrders()
        {
            return orderRepository.GetOrders();
        }

        public void Update(Order entity)
        {
            orderRepository.Update(entity);
        }
    }
}
