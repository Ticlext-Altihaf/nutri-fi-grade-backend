using System.Text.Json;
using Server.Models;

namespace Server.AI.Methods;

public class EAN13Method
{

    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<string> GetProductInformation(string ean13)
    {
        var response = await _httpClient.GetAsync($"https://world.openfoodfacts.org/api/v0/product/{ean13}.json");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
          //  var product = JsonSerializer.Deserialize<Ean13Product>(content);
            return content;

        }
        return null;
    }
}