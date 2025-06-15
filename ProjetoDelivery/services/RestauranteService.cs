using System.Net.Http.Json;
using ProjetoDelivery.Models;

namespace ProjetoDelivery.Services;

public class RestauranteService
{
    private readonly HttpClient _http;

    public RestauranteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Restaurante>> ListarAsync()
    {
        return await _http.GetFromJsonAsync<List<Restaurante>>("http://localhost:5291/api/restaurante") ?? new();
    }

    public async Task<Restaurante?> BuscarPorIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Restaurante>($"http://localhost:5291/api/restaurante/{id}");
    }

    public async Task<List<Restaurante>> ListarTodosAsync()
    {
        return await _http.GetFromJsonAsync<List<Restaurante>>("http://localhost:5291/api/restaurante") ?? new();
    }


    public async Task<List<Alimento>> ListarCardapioPorRestauranteAsync(int restauranteId)
       {
            return await _http.GetFromJsonAsync<List<Alimento>>($"http://localhost:5291/api/restaurante/{restauranteId}/cardapio")
            ?? new List<Alimento>();
       }
}
