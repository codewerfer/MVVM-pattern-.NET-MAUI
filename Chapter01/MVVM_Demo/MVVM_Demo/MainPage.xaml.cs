using System.Text.Json;

namespace MVVM_Demo;

public class ZenQuote
{
    public string q { get; set; }
    public string a { get; set; }
    public string h { get; set; }
}

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        GetQuoteButton.IsVisible = false;

        try
        {
            var client = new HttpClient();

            string quote = await
                client.GetStringAsync(
                "https://zenquotes.io/api/today");

            var x = JsonSerializer.Deserialize<ZenQuote[]>(quote, JsonSerializerOptions.Default);

            QuoteLabel.Text = x[0].q;

            QuoteLabel.IsVisible = true;
        }
        catch (Exception)
        {
        }
    }
}

