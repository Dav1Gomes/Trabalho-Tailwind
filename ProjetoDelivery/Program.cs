using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjetoDelivery;
using ProjetoDelivery.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<SessionService>();

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped(sp => new HttpClient());

builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("https://localhost:5291/") 
});

builder.Services.AddScoped<UserStateService>();
builder.Services.AddScoped<UsuarioService>();



await builder.Build().RunAsync();
