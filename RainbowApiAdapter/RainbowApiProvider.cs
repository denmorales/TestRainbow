using IdentityModel.Client;
using RainbowApiAdapter.Dto;
using System.Text.Json;

namespace RainbowApiAdapter;

public class RainbowApiProvider
{

    public async Task<DocumentDto?> GetDocument(long id)
    {
        var url = $"http://api-test.tdera.ru/api/getdocument?id={id}";
        var client = new HttpClient();
        client.SetBasicAuthentication("l12345678", "p12345678");
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var document = JsonSerializer.Deserialize<DocumentDto>(result);
            return document;
        }

        return null;
    }

    public async Task<DocumentListDto.Datum[]?> GetRouteBoxes(string routeId)
    {
        var url = $"http://api-test.tdera.ru/api/getdocumentlist";
        var client = new HttpClient();
        client.SetBasicAuthentication("l12345678", "p12345678");
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var document = JsonSerializer.Deserialize<DocumentListDto>(result);
            if (document.exception.error != 0)
            {
                throw new Exception(document.exception.error_msg.ToString());
            }

            return document.data.Where(d => d.nom_route.Trim().Equals(routeId, StringComparison.InvariantCultureIgnoreCase)).ToArray();
        }

        return null;
    }
}