using Microsoft.Extensions.Configuration;

namespace WebApp.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }

        private readonly IConfiguration _configuration;
        private readonly string _url;

        public Client(IConfiguration configuration)
        {
            _configuration = configuration;
            _url = _configuration.GetSection("ApiAddress:Url").Value ?? "is null";
        }

    }
}
