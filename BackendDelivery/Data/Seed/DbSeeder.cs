using BackendDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendDelivery.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        db.Database.Migrate();

        if (!db.Restaurantes.Any())
        {
            var r1 = new Restaurante
            {
                Nome = "Sabor Nordestino",
                Local = "Rua Principal, 123",
                Tipo = "Brasileira",
                Nota = 4.7,
                Alimentos = new List<Alimento>
                {
                    new Alimento
                    {
                        Nome = "Baião de Dois",
                        Preco = 19.90m,
                        Nota = 4.8,
                        Descricao = "Prato típico com arroz, feijão verde e queijo coalho.",
                        TempoPreparo = 25,
                        Tipo = "Prato Principal"
                    },
                    new Alimento
                    {
                        Nome = "Cuscuz com Carne de Sol",
                        Preco = 15.50m,
                        Nota = 4.5,
                        Descricao = "Cuscuz nordestino com carne de sol desfiada.",
                        TempoPreparo = 20,
                        Tipo = "Prato Principal"
                    }
                }
            };

            var r2 = new Restaurante
            {
                Nome = "Pizzaria Italiana",
                Local = "Avenida Itália, 456",
                Tipo = "Italiana",
                Nota = 4.9,
                Alimentos = new List<Alimento>
                {
                    new Alimento
                    {
                        Nome = "Pizza Margherita",
                        Preco = 34.90m,
                        Nota = 4.9,
                        Descricao = "Molho de tomate, mussarela, manjericão fresco.",
                        TempoPreparo = 30,
                        Tipo = "Pizza"
                    },
                    new Alimento
                    {
                        Nome = "Pizza Calabresa",
                        Preco = 36.00m,
                        Nota = 4.7,
                        Descricao = "Calabresa fatiada, cebola roxa e mussarela.",
                        TempoPreparo = 30,
                        Tipo = "Pizza"
                    }
                }
            };

            db.Restaurantes.AddRange(r1, r2);
            db.SaveChanges();
        }
    }
}
