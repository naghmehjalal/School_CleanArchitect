namespace WebApp.Contracts
{
    public interface ILocalStorageService
    {
        void ClearStorage(List<string> key);
        bool Exists(string key);

        T GetStorageValue<T>(string key);
        void SetStorageValue<T>(string key, T value);


    }
}
