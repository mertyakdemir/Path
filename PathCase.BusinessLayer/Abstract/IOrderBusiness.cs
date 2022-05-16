using PathCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.BusinessLayer.Abstract
{
    public interface IOrderBusiness
    {
        void Create(Order entity);
        void Update(Order entity);
        List<Order> GetOrders();
        Order GetOrder(int orderId);
    }
}
