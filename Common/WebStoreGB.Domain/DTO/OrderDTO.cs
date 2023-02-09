using System;
using System.Collections.Generic;

namespace WebStoreGB.Domain.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Description { get; set; }
        public IEnumerable<OrderItemDTO> Items { get; set; }
    }
}
