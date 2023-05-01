using Newtonsoft.Json;

namespace QuoteCalculatorMVC.Services
{
    public abstract class BaseService 
    {
        protected readonly string _baseEndpoint;
        public BaseService(IConfiguration config)
        {
            _baseEndpoint = config.GetValue<string>("quoteCalculatorEndpoint");
        }

        protected async Task<T>  GetAsyncBase<T>( string endpoint)
        {
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri($"{_baseEndpoint}{endpoint}");

                var result = await httpclient.GetAsync(httpclient.BaseAddress);

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());

                throw new HttpRequestException();
            }
        }

        protected async Task PostAsyncBase<T>(T entity , string endpoint)
        {
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri($"{_baseEndpoint}{endpoint}");

                var result = await httpclient.PostAsJsonAsync(httpclient.BaseAddress,entity);

                if (result.IsSuccessStatusCode)
                    return;

                throw new HttpRequestException();
            }
        }
    }
}
