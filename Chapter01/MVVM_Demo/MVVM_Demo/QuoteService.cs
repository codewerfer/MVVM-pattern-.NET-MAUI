using System.Text.Json;

namespace MVVM_Demo;

public interface IQuoteService
{
    Task<string> GetQuote();
}

public class QuoteService : IQuoteService
{
    private readonly HttpClient httpClient;

    public QuoteService()
    {
        httpClient = new HttpClient();
    }

    public async Task<string> GetQuote()
    {
        var response = await httpClient.GetAsync("https://zenquotes.io/api/today");

        if (response.IsSuccessStatusCode)
        {
            var x = await JsonSerializer.DeserializeAsync<ZenQuote[]>(await response.Content.ReadAsStreamAsync(), JsonSerializerOptions.Default);
            return await Task.FromResult(x[0].q);
        }

        throw new Exception("Failed to retrieve quote.");
    }
}
