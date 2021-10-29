using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;

namespace MerchandiseService.HttpClient
{
    public class MerchandiseHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchandiseHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchOrderResponse> GetMerchOrderById(long id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"https://localhost:5001/v1/api/MerchOrders/get/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchOrderResponse>(body);
        }
    }
}