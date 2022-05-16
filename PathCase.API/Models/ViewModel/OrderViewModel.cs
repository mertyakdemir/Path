using PathCase.Entities;
using System.Collections.Generic;

namespace PathCase.API.Models.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
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
