using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Client.Models;
using InfluencerApp.Services;

namespace Client.Pages;

public partial class Index
{
    [Parameter]
    public string orderId { get; set; } = "";

    [Inject]
    public HttpClient HttpClient { get; set; } = default!;

    [Inject]
    public IJSRuntime JsRuntime { get; set; } = default!;

    private List<Product>? _products;
    private Product? Products;
    private IEnumerable<Product[]>? _productChunksOf4;

    //private const string DevApiBaseAddress = "https://localhost:7077";

    protected override async Task OnInitializedAsync()
    {
        //_products = await OrderService.CheckoutOrderById(orderId);
        await Task.Delay(1);
    }

    private async Task OnClickBtnBuyNowAsync(List<Product> product)
    {
        var _HttpClient = new HttpClient();
        var response = await HttpClient.PostAsJsonAsync($"{APIs._baseUrl}checkout", product);

        response.EnsureSuccessStatusCode();

        var responseBody = await response.Content.ReadAsStringAsync();

        var checkoutOrderResponse = JsonConvert.DeserializeObject<CheckoutOrderResponse>(responseBody);

        // Opens up Stripe.
        await JsRuntime.InvokeVoidAsync("checkout", checkoutOrderResponse.PubKey, checkoutOrderResponse.SessionId);
    }
    protected override async Task OnParametersSetAsync()
    {
        _products = await OrderService.CheckoutOrderById(orderId);
        await Task.Delay(1);

        if (_products.Any() == true)
        {
            await OnClickBtnBuyNowAsync(_products);
        }
    }

    //private async Task OnClickBtnBuyNowAsync(Product product)
    //{
    //    var response = await HttpClient.PostAsJsonAsync($"{DevApiBaseAddress}/checkout", product);

    //    response.EnsureSuccessStatusCode();

    //    var responseBody = await response.Content.ReadAsStringAsync();

    //    var checkoutOrderResponse = JsonConvert.DeserializeObject<CheckoutOrderResponse>(responseBody);

    //    // Opens up Stripe.
    //    await JsRuntime.InvokeVoidAsync("checkout", checkoutOrderResponse.PubKey, checkoutOrderResponse.SessionId);
    //}
}
