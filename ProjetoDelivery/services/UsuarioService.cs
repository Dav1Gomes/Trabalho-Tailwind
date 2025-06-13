using System.Net.Http.Json;
using System.Threading.Tasks;
using BackendDelivery.Models;
using ProjetoDelivery.Models;

namespace ProjetoDelivery.Services;

public class UsuarioService
{
    private readonly HttpClient _http;

    public UsuarioService(HttpClient http)
    {
        _http = http;
    }

    public async Task<HttpResponseMessage> RegistrarAsync(Usuario usuario)
    {
        return await _http.PostAsJsonAsync("http://localhost:5291/api/usuario/registro", usuario);
    }

    public async Task<HttpResponseMessage> LoginAsync(LoginRequest login)
    {
        return await _http.PostAsJsonAsync("http://localhost:5291/api/usuario/login", login);
    }

    public async Task<Usuario?> BuscarPorIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Usuario>($"http://localhost:5291/api/usuario/{id}");
    }

    public async Task<HttpResponseMessage> EditarUsuarioAsync(int id, Usuario usuario)
    {
        return await _http.PutAsJsonAsync($"http://localhost:5291/api/usuario/editar/{id}", usuario);
    }

    public async Task<List<Cartao>?> ListarCartoesAsync(int id)
    {
        return await _http.GetFromJsonAsync<List<Cartao>>($"http://localhost:5291/api/usuario/{id}/cartoes");
    }

    public async Task<HttpResponseMessage> AdicionarCartaoAsync(int id, Cartao cartao)
    {
        return await _http.PostAsJsonAsync($"http://localhost:5291/api/usuario/{id}/cartoes", cartao);
    }

    public async Task<bool> AdicionarSaldoAsync(int usuarioId, decimal valor)
    {
        var response = await _http.PostAsJsonAsync($"http://localhost:5291/api/usuario/{usuarioId}/add-saldo", valor);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<Cartao>> ObterCartoesAsync(int usuarioId)
    {
        var response = await _http.GetFromJsonAsync<List<Cartao>>($"http://localhost:5291/api/usuario/{usuarioId}/cartoes");
        return response ?? new List<Cartao>();
    }



}
