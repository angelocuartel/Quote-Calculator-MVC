namespace QuoteCalculatorMVC.Services
{
    public interface IQuoteService
    {
        Task<T1> GetAsync<T1>(string hashedId);
        Task PostAsync<T2>(T2 entity);
    }
}
