using System.Net.Http;
using System.Threading.Tasks;

namespace TestWeb21
{
    public class ValueController
    {
        public ValueController(IHttpClientFactory clientFactory)
        {
            _ClientFactory = clientFactory;
        }

        public IHttpClientFactory _ClientFactory { get; }

        public async Task<string[]> GetValue()
        {
            var client = _ClientFactory.CreateClient();
            await client.GetAsync("http://bing.com");

            var client2 = _ClientFactory.CreateClient("Jeff");
            await client2.GetAsync("/Issues");

            return new string[] {"value1", "value2"};
        }
    }
}