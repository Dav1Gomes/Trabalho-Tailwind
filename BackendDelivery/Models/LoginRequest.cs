namespace BackendDelivery.Models;

public record LoginRequest(
    string Email,
    string Senha
);
