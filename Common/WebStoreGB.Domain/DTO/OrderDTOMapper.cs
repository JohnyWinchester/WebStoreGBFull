using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities;
using WebStoreGB.Domain.Entities.Orders;
using WebStoreGB.Domain.ViewModels;

namespace WebStoreGB.Domain.DTO
{
    public static class OrderDTOMapper
    {
        public static OrderItemDTO ToDTO(this OrderItem item) => item is null
            ? null
            : new OrderItemDTO
            {
                Id = item.Id,
                ProductId = item.Product.Id,
                Price = item.Price,
                Quantity = item.Quantity,
            };

        public static OrderItem FromDTO(this OrderItemDTO item) => item is null
            ? null
            : new OrderItem
            {
                Id = item.Id,
                Product = new Product { Id = item.Id },
                Price = item.Price,
                Quantity = item.Quantity,
            };

        public static OrderDTO ToDTO(this Order order) => order is null
            ? null
            : new OrderDTO
            {
                Id = order.Id,
                Phone= order.Phone,
                Address = order.Address,
                Date= order.Date,
                Description= order.Description,
                Items = order.Items.Select(ToDTO),
            };

        public static Order FromDTO(this OrderDTO order) => order is null
            ? null
            : new Order
            {
                Id = order.Id,
                Phone = order.Phone,
                Address= order.Address,
                Date= order.Date,
                Description= order.Description,
                Items = order.Items.Select(FromDTO).ToList(),
            };

        public static IEnumerable<OrderDTO> ToDTO(this IEnumerable<Order> orders) => orders.Select(ToDTO);
        public static IEnumerable<Order> FromDTO(this IEnumerable<OrderDTO> orders) => orders.Select(FromDTO);

        // если у нас есть CartViewModel то из неё можно сформировать IEnumerable<ItemOrderDTO>
        public static IEnumerable<OrderItemDTO> ToDTO(this CartViewModel cart) =>
            cart.Items.Select(p => new OrderItemDTO
            {
                ProductId = p.Product.Id,
                Price = p.Product.Price,
                Quantity = p.Quantity,
            });
        // и обратно в CartViewModel
        public static CartViewModel ToCartView(this IEnumerable<OrderItemDTO> items) =>
            new CartViewModel
            {
                Items = items.Select(p => (new ProductViewModel { Id = p.ProductId}, p.Quantity))
            };
    }
}
