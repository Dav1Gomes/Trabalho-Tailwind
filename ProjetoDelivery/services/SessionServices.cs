using Microsoft.JSInterop;
using System.Threading.Tasks;

public class SessionService
{
    private readonly IJSRuntime _jsRuntime;
    private const string StorageKey = "isLoggedIn";

    public bool IsLoggedIn { get; private set; } = false;

    public SessionService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        var logged = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", StorageKey);
        IsLoggedIn = logged == "true";
    }

    public async Task LoginAsync()
    {
        IsLoggedIn = true;
        await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", StorageKey, "true");
    }

    public async Task Logout()
    {
        IsLoggedIn = false;
        await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", StorageKey);
    }
}
