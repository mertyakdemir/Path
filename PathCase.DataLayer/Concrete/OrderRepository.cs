using PathCase.DataLayer.Abstract;
using PathCase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.DataLayer.Concrete
{
    public class OrderRepository : GenericRepository<Order, DatabaseContext>, IOrderRepository
    {
        public List<Order> GetOrders()
        {
            using var dbContext = new DatabaseContext();
            var orders = dbContext.Orders.ToList();

            return orders;
        }

        public Order GetOrder(int orderId)
        {
            using var dbContext = new DatabaseContext();
            var order = dbContext.Orders.Where(x => x.Id == orderId).FirstOrDefault();


            return order;
        }
    }
}
