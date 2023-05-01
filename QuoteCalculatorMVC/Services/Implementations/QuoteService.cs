using Newtonsoft.Json;
using QuoteCalculatorMVC.Models;
using System.Net;

namespace QuoteCalculatorMVC.Services.Implementations
{
    public class QuoteService : BaseService , IQuoteService
    {
        public QuoteService(IConfiguration config) : 
            base(config)
        {
        }

        public async Task PostAsync<T2>(T2 entity)
        {
            string endpoint = "api/Quote/payment";
            await this.PostAsyncBase(entity, endpoint);
        }

        public async Task<T1> GetAsync<T1>(string hashedId)
        {
            string endpoint = "api/Quote/" + hashedId;
            return await this.GetAsyncBase<T1>(endpoint);
        }
    }
}
