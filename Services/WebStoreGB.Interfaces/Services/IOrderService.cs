using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities.Orders;
using WebStoreGB.Domain.ViewModels;

namespace WebStoreGB.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrders(string User);
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(string UserName, CartViewModel Cart, OrderViewModel OrderModel);
    }
}
