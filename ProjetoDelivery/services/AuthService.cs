namespace ProjetoDelivery.services
{
    public class AuthService
    {
        public bool IsLoggedIn { get; private set; } = false;

        public void Login(string email, string password)
        {
            if (email == "usuario@email.com" && password == "123")
            {
                IsLoggedIn = true;
            }
        }

        public void Logout()
        {
            IsLoggedIn = false;
        }
    }
}
