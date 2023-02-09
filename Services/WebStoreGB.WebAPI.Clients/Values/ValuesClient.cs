using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Interfaces;
using WebStoreGB.Interfaces.TestAPI;
using WebStoreGB.WebAPI.Clients.Base;

namespace WebStoreGB.WebAPI.Clients.Values
{
    public class ValuesClient : BaseClient, IValuesService
    {
        public ValuesClient(HttpClient Client) : base(Client, WebAPIAddresses.Values)
        {

        }
        // Реализуем методы доступа к веб апи
        // берём Http клиента и делаем запрос на аддресс контролера

        //Post
        public void Add(string value)
        {
            var response = Http.PostAsJsonAsync(Address, value).Result;
            response.EnsureSuccessStatusCode();
        }

        public int Count()
        {
            var response = Http.GetAsync($"{Address}/count").Result;
            if (response.IsSuccessStatusCode) // если успешно то десеарилезуем данные
                return response.Content.ReadFromJsonAsync<int>().Result;

            return -1;
        }

        public bool Delete(int id)
        {
            var response = Http.DeleteAsync($"{Address}/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        //Put
        public void Edit(int id, string value)
        {
            var response = Http.PutAsJsonAsync($"{Address}/{id}", value).Result;
            response.EnsureSuccessStatusCode();
        }

        public IEnumerable<string> GetAll()
        {
            var response = Http.GetAsync(Address).Result;
            //HttpResponseMessage message = new HttpResponseMessage();
            //try
            //{
            //    message = Http.GetAsync(Address).Result;
            //    //response = message;
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.InnerException.Message);
            //}
            //catch (HttpRequestException e)
            //{
            //    Console.WriteLine(e.InnerException.InnerException?.Message);
            //    //Console.WriteLine(e.InnerException.Message);
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.InnerException.InnerException?.Message);
            //    //Console.WriteLine(e.InnerException.Message);
            //}

            if (response.IsSuccessStatusCode) // если успешно то десеарилезуем данные
                return response.Content.ReadFromJsonAsync<IEnumerable<string>>().Result;
            
            return Enumerable.Empty<string>();
        }

        public string GetById(int id)
        {
            var response = Http.GetAsync($"{Address}/{id}").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadFromJsonAsync<string>().Result;

            return null;
        }
    }
}
