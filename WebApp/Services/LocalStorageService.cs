using WebApp.Contracts;
using Hanssens.Net;

namespace WebApp.Services
{
    public class LocalStorageService : ILocalStorageService
    {

        LocalStorage _storage;

        public LocalStorageService()
        {
            var conf = new LocalStorageConfiguration()
            {
                AutoLoad = true,
                AutoSave = true,
                Filename = "School_Storage"
            };

            _storage = new LocalStorage(conf);
        }

        public void ClearStorage(List<string> keys)
        {
            foreach (var key in keys)
                _storage.Remove(key);
        }

        public void SetStorageValue<T>(string key, T value)
        {
            _storage.Store(key, value);
            _storage.Persist();
        }  
        
        public T GetStorageValue<T>(string key)
        {
           return (T) _storage.Get(key);
        }

        public bool Exists(string key)
        {
           return _storage.Exists(key);
        }

     

    }
}
