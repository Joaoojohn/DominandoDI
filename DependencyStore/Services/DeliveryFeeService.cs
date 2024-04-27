using DependencyStore.Services.Constracts;
using RestSharp;

namespace DependencyStore.Services
{
    public class DeliveryFeeService : IDeliveryFeesService
    {
        public async Task<decimal> GetDeliveryFeeAsync(string zipCode)
        {
            decimal deliveryFee = 0;

            var client = new RestClient("https://consultafrete.io/cep/");
            
            var request = new RestRequest().AddJsonBody(new
                {
                    zipCode
                });
            
            var response = await client.PostAsync<decimal>(request, new CancellationToken());

            return response < 5 ? 5 : response;
        }
    }
}
