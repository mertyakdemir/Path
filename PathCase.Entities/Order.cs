using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCase.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public EnumOrderState OrderState { get; set; }
        public int ProductNumber { get; set; }
        public int CategoryNumber { get; set; }
        public int ShipType { get; set; }
    }

    public enum EnumOrderState
    {
        PendingOrder = 0,
        ConfirmedOrder = 1,
        OrderInPreparation = 2,
        ShippedOrder = 3,
        RejectedOrder = 4
    }

    
}
