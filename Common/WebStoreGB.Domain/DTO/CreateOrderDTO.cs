using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities.Orders;
using WebStoreGB.Domain.ViewModels;

namespace WebStoreGB.Domain.DTO
{
    public class CreateOrderDTO
    {
        public OrderViewModel Order { get; set; }
        public IEnumerable<OrderItemDTO> Items { get; set; }
    }
}
