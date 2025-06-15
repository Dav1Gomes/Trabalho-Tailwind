using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjetoDelivery;
using ProjetoDelivery.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5291/")
});

builder.Services.AddScoped<SessionService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<UserStateService>();
builder.Services.AddScoped<RestauranteService>();


await builder.Build().RunAsync();

