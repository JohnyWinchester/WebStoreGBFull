using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net;
using System.Threading.Tasks;

namespace WebStore.TestConsole
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new HubConnectionBuilder();
            var connection = builder.WithUrl("https://localhost:5000/chat").Build();

            using var registrarion = connection.On<string>("MessageFromClient",OnMesageFromClient);

            Console.WriteLine("Готов к подключению");
            Console.ReadLine();

            await connection.StartAsync();
            Console.WriteLine("Соединение установлено ");

            while (true)
            {
                var message = Console.ReadLine();
                await connection.InvokeAsync("SendMessage",message);
            }

            //Console.ReadKey();
        }

        private static void OnMesageFromClient(string Message)
        {
            Console.WriteLine("Message from Server {0}",Message);
        }
    }
}
