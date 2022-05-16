using PathCase.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PathCase.API.Models.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int? ProductCategoryId { get; set; }
    }
}
