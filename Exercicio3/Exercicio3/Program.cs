using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

void ExemploGet(string titulo, string uri) {
    Console.WriteLine(titulo);

    using var cliente = new HttpClient();

    var request = new HttpRequestMessage(
        HttpMethod.Get,
        uri);
    Console.WriteLine(" -- Requisição GET");

    using var response = cliente.Send(request);

    Console.WriteLine("Retorno: ");
    Console.WriteLine($"Status Code: {response.StatusCode}");
    Console.WriteLine($"Corpo: {response.Content.ReadAsStringAsync().Result}");
    Console.WriteLine($"Headers: {string.Join(',', response.Headers.Select(h => $"{h.Key}={string.Join(',',h.Value)}"))}");
}

ExemploGet("GET - Anime Facts API","https://anime-facts-rest-api.herokuapp.com/api/v1/one_piece");

ExemploGet("GET - Bored API","http://www.boredapi.com/api/activity?participants=2");