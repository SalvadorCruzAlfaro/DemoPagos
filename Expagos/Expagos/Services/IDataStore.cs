using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expagos.Services
{
    public interface IDataStore
    {
        Task<bool> AddItemAsync<T>(T item, string apiName, string actionName) where T : class, new();
        Task<bool> UpdateItemAsync<T>(T item, string apiName, string actionName) where T : class, new();
        Task<bool> DeleteItemAsync<T>(T item, string apiName, string actionName) where T : class, new();
        Task<T> GetItemAsync<T>(int id, string apiName) where T : class, new();
        Task<IEnumerable<T>> GetItemsAsync<T>(string apiName, string actionName, bool forceRefresh = false) where T : class, new();

        Task<IEnumerable<T>> GetItemsAsync<T>(string apiName, string actionName, string parameterName,
            dynamic valueParameter) where T : class, new();
    }
}
