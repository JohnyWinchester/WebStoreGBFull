using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebStoreGB.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string Message) => await Clients.All.SendAsync("MessageFromClient",Message); // messageFromClient это тот метод который есть у клиента и который хаб может вызвать и передать ему данные
    }
}
