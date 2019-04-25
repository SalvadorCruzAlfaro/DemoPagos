using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Expagos.Services
{
    public class ApiDataStore : IDataStore
    {
        HttpClient client;
        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public ApiDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.AzureBackendUrl}/");
        }

        public async Task<bool> AddItemAsync<T>(T item, string apiName, string actionName) where T : class, new()
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/{apiName}/{actionName}", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync<T>(T item, string apiName, string actionName) where T : class, new()
        {
            try
            {
                if (item == null || !IsConnected)
                    return false;

                var serializedItem = JsonConvert.SerializeObject(item);

                var response = await client.PutAsync($"api/{apiName}/{actionName}", new StringContent(serializedItem, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync<T>(T item, string apiName, string actionName) where T : class, new()
        {
            try
            {
                if (item == null || !IsConnected)
                    return false;

                var serializedItem = JsonConvert.SerializeObject(item);

                var response = await client.PutAsync($"api/{apiName}/{actionName}", new StringContent(serializedItem, Encoding.UTF8, "application/json")).ConfigureAwait(false);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<T> GetItemAsync<T>(int id, string apiName) where T : class, new()
        {
            try
            {
                if (id != null && IsConnected)
                {
                    var json = await client.GetStringAsync($"api/{apiName}/{id}");
                    return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>(string apiName, string actionName, bool forceRefresh = false) where T : class, new()
        {
            try
            {
                IEnumerable<T> items = null;
                if (forceRefresh && IsConnected)
                {
                    var json = await client.GetStringAsync($"api/{apiName}/{actionName}");
                    items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<T>>(json));
                }
                return items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>(string apiName, string actionName, string parameterName, dynamic valueParameter) where T : class, new()
        {
            try
            {
                IEnumerable<T> items = null;
                if (IsConnected)
                {
                    var json = await client.GetStringAsync($"api/{apiName}/{actionName}?{parameterName}={valueParameter}");
                    items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<T>>(json));
                }
                return items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
