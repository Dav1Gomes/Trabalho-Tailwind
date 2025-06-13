namespace ProjetoDelivery.Services;

public class UserStateService
{
    public string UserName { get; set; } = string.Empty;
    public int UserId { get; set; }
    public decimal Saldo { get; set; }

    public event Action? OnChange;

    public void SetUser(int id, string nome, decimal saldo)
    {
        UserId = id;
        UserName = nome;
        Saldo = saldo;
        NotifyStateChanged();   
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
