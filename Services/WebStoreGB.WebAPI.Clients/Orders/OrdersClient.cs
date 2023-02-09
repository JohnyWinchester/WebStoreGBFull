using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.DTO;
using WebStoreGB.Domain.Entities.Orders;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.WebAPI.Clients.Base;

namespace WebStoreGB.WebAPI.Clients.Orders
{
    public class OrdersClient : BaseClient, IOrderService
    {
        public OrdersClient(HttpClient Client) : base(Client, WebAPIAddresses.Orders)
        {

        }

        public async Task<Order> CreateOrder(string UserName, CartViewModel Cart, OrderViewModel OrderModel)
        {
            var model = new CreateOrderDTO { Order = OrderModel, Items = Cart.ToDTO() };
            var result = await PostAsync($"{Address}/{UserName}", model).ConfigureAwait(false);
            var order = await result
                .EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<OrderDTO>()
                .ConfigureAwait(false);
            return order.FromDTO();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var result = await GetAsync<OrderDTO>($"{Address}/{id}").ConfigureAwait(false);
            return result.FromDTO();
        }

        public async Task<IEnumerable<Order>> GetUserOrders(string User)
        {
            var result = await GetAsync<IEnumerable<OrderDTO>>($"{Address}/user/{User}").ConfigureAwait(false);
            return result.FromDTO();
        }
    }
}
