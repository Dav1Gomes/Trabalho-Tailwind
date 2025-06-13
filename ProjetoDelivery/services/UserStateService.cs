public class UserStateService
{
    public string UserName { get; private set; }
    public event Action OnChange;

    public void SetUser(string userName)
    {
        UserName = userName;
        OnChange?.Invoke();
    }
}
