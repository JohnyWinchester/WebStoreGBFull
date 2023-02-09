using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebStoreGB.WebAPI.Clients.Base
{
    // каждый клиент будет указывать базовому классу с кеким контролером он будет сотрудничать
    public abstract class BaseClient: IDisposable
    {
        protected HttpClient Http { get; }
        protected string Address { get; } 
        protected BaseClient(HttpClient Client, string Address) 
        {
            Http = Client;
            this.Address = Address;
        }

        protected T Get<T>(string url) => GetAsync<T>(url).Result;
        protected async Task<T> GetAsync<T>(string url, CancellationToken cancel = default)
        {
            var response = await Http.GetAsync(url).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.NoContent) return default;

            return await response
                .EnsureSuccessStatusCode()
                .Content
                .ReadFromJsonAsync<T>(cancellationToken:cancel)
                .ConfigureAwait(false);
        }

        //принимает адрес куда надо отправить и отправляемый объект
        protected HttpResponseMessage Post<T>(string url, T item) => PostAsync<T>(url, item).Result;
        protected async Task<HttpResponseMessage> PostAsync<T>(string url, T item, CancellationToken cancel = default)
        {
            var response = await Http.PostAsJsonAsync(url, item, cancellationToken: cancel).ConfigureAwait(false);
            return response.EnsureSuccessStatusCode();
        }

        protected HttpResponseMessage Delete(string url) => DeleteAsync(url).Result;
        protected async Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken cancel = default)
        {
            var response = await Http.DeleteAsync(url, cancellationToken: cancel).ConfigureAwait(false);
            return response;
        }

        protected HttpResponseMessage Put<T>(string url, T item) => PutAsync<T>(url, item).Result;
        protected async Task<HttpResponseMessage> PutAsync<T>(string url, T item, CancellationToken cancel = default)
        {
            var response = await Http.PutAsJsonAsync(url, item, cancellationToken: cancel).ConfigureAwait(false);
            return response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _Disposed;

        //мы можем переопределить в наследниках и освободить ресурсы которые в них появляются
        protected virtual void Dispose(bool disposing)
        {
            if(_Disposed) return;
            _Disposed = true;

            if (disposing)
            {
                //должны освободить управляемы ресурсы, т.е. вызвать метод Dispose у всего у чего есть этот метод
                //Http.Dispose(); не мы создавали объект, не мы его удаляем. Он создаётся в контейнере сервисов, контейнер за него и отвечает
            }

            //далее должны освободить неуправляемые ресурсы
        }
    }
}
