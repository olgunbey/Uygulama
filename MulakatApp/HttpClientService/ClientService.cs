using MulakatApp.Models;

namespace MulakatApp.HttpClientService
{
    public class ClientService
    {
        private readonly HttpClient _httpClient;
        public ClientService(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }
        public async Task<Root> RootClient(string name)
        {
            return await _httpClient.GetFromJsonAsync<Root>($"{name}");
        }
    }
}
