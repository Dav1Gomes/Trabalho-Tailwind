using System.Collections.Generic;
using System.Linq;
using BackendDelivery.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendDelivery.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            db.Database.Migrate();

            if (!db.Restaurantes.Any())
            {
                var r1 = new Restaurante
                {
                    Nome = "Procopão Bar",
                    Local = "R. Mariano Procópio, 1115 - Centro, Juiz de Fora - MG, 36035-780",
                    Tipo = "Brasileira",
                    Nota = 4.7,
                    Alimentos = new List<Alimento>
                    {
                        new Alimento
                        {
                            Nome = "Feijoada",
                            Preco = 19.90m,
                            Nota = 4.8,
                            Descricao = "Prato típico com arroz, feijão verde e queijo coalho.",
                            FotoUrl = "https://lh3.googleusercontent.com/p/AF1QipOGSD5l54xp-OF0XI8EBPToKXYBZIdHmxO5pawM=s680-w680-h510-rw",
                            TempoPreparo = 25,
                            Tipo = "Prato Principal"
                        },
                        new Alimento
                        {
                            Nome = "Feijuca",
                            Preco = 15.50m,
                            Nota = 4.5,
                            Descricao = "Cuscuz nordestino com carne de sol desfiada.",
                            FotoUrl = "https://lh3.googleusercontent.com/p/AF1QipONYRIFgRmXzfv_6xXPLk0_hbjfAZwlJZi-phkB=s680-w680-h510-rw",
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

                var r3 = new Restaurante
                {
                    Nome = "Comida Japonesa",
                    Local = "Rua Sakura, 78",
                    Tipo = "Japonesa",
                    Nota = 4.8,
                    Alimentos = new List<Alimento>
                    {
                        new Alimento
                        {
                            Nome = "Sushi de Salmão",
                            Preco = 25.00m,
                            Nota = 4.9,
                            Descricao = "Fatias de salmão fresco sobre arroz temperado.",
                            TempoPreparo = 15,
                            Tipo = "Sushi"
                        },
                        new Alimento
                        {
                            Nome = "Ramen Tradicional",
                            Preco = 28.00m,
                            Nota = 4.7,
                            Descricao = "Caldo rico, macarrão e acompanhamentos tradicionais.",
                            TempoPreparo = 20,
                            Tipo = "Sopa"
                        },
                        new Alimento
                        {
                            Nome = "Tempura de Camarão",
                            Preco = 22.00m,
                            Nota = 4.6,
                            Descricao = "Camarões empanados e fritos, crocantes por fora.",
                            TempoPreparo = 18,
                            Tipo = "Petisco"
                        },
                        new Alimento
                        {
                            Nome = "Yakissoba",
                            Preco = 20.00m,
                            Nota = 4.5,
                            Descricao = "Macarrão salteado com legumes variados.",
                            TempoPreparo = 15,
                            Tipo = "Massa"
                        },
                        new Alimento
                        {
                            Nome = "Sashimi Misto",
                            Preco = 30.00m,
                            Nota = 4.8,
                            Descricao = "Seleção de peixes crus frescos em fatias finas.",
                            TempoPreparo = 10,
                            Tipo = "Sashimi"
                        }
                    }
                };

                var r4 = new Restaurante
                {
                    Nome = "Hamburgueria Gourmet",
                    Local = "Rua Burger, 99",
                    Tipo = "Fast Food",
                    Nota = 4.6,
                    Alimentos = new List<Alimento>
                    {
                        new Alimento
                        {
                            Nome = "Cheeseburger Clássico",
                            Preco = 18.50m,
                            Nota = 4.7,
                            Descricao = "Carne suculenta com queijo cheddar.",
                            TempoPreparo = 12,
                            Tipo = "Hambúrguer"
                        },
                        new Alimento
                        {
                            Nome = "Bacon Burger",
                            Preco = 22.00m,
                            Nota = 4.8,
                            Descricao = "Hambúrguer com bacon crocante.",
                            TempoPreparo = 14,
                            Tipo = "Hambúrguer"
                        },
                        new Alimento
                        {
                            Nome = "Veggie Burger",
                            Preco = 20.00m,
                            Nota = 4.5,
                            Descricao = "Hambúrguer de grãos e vegetais.",
                            TempoPreparo = 15,
                            Tipo = "Hambúrguer"
                        },
                        new Alimento
                        {
                            Nome = "Chicken Burger",
                            Preco = 19.90m,
                            Nota = 4.6,
                            Descricao = "Filé de frango empanado com salada.",
                            TempoPreparo = 13,
                            Tipo = "Hambúrguer"
                        },
                        new Alimento
                        {
                            Nome = "Double Cheese",
                            Preco = 24.00m,
                            Nota = 4.9,
                            Descricao = "Dobro de carne e queijo cheddar.",
                            TempoPreparo = 15,
                            Tipo = "Hambúrguer"
                        }
                    }
                };

                var r5 = new Restaurante
                {
                    Nome = "Churrascaria Gaúcha",
                    Local = "Estrada do Sul, 543",
                    Tipo = "Churrasco",
                    Nota = 4.8,
                    Alimentos = new List<Alimento>
                    {
                        new Alimento
                        {
                            Nome = "Picanha na Brasa",
                            Preco = 45.00m,
                            Nota = 4.9,
                            Descricao = "Fatias de picanha ao ponto.",
                            TempoPreparo = 20,
                            Tipo = "Carne"
                        },
                        new Alimento
                        {
                            Nome = "Costela Fatiada",
                            Preco = 40.00m,
                            Nota = 4.7,
                            Descricao = "Costela cozida lentamente na brasa.",
                            TempoPreparo = 25,
                            Tipo = "Carne"
                        },
                        new Alimento
                        {
                            Nome = "Linguiça Blumenau",
                            Preco = 18.00m,
                            Nota = 4.6,
                            Descricao = "Linguiça típica de Blumenau.",
                            TempoPreparo = 15,
                            Tipo = "Carne"
                        },
                        new Alimento
                        {
                            Nome = "Frango com Bacon",
                            Preco = 25.00m,
                            Nota = 4.5,
                            Descricao = "Espeto de frango enrolado em bacon.",
                            TempoPreparo = 18,
                            Tipo = "Carne"
                        },
                        new Alimento
                        {
                            Nome = "Maminha Fatiada",
                            Preco = 38.00m,
                            Nota = 4.8,
                            Descricao = "Maminha macia e suculenta.",
                            TempoPreparo = 22,
                            Tipo = "Carne"
                        }
                    }
                };

                var r6 = new Restaurante
                {
                    Nome = "Cafeteria & Doces",
                    Local = "Av. Café, 321",
                    Tipo = "Cafeteria",
                    Nota = 4.7,
                    Alimentos = new List<Alimento>
                    {
                        new Alimento
                        {
                            Nome = "Cappuccino",
                            Preco = 9.00m,
                            Nota = 4.8,
                            Descricao = "Café com leite e espuma cremosa.",
                            TempoPreparo = 5,
                            Tipo = "Bebida"
                        },
                        new Alimento
                        {
                            Nome = "Bolo de Chocolate",
                            Preco = 12.50m,
                            Nota = 4.7,
                            Descricao = "Bolo fofinho com cobertura.",
                            TempoPreparo = 0,
                            Tipo = "Sobremesa"
                        },
                        new Alimento
                        {
                            Nome = "Croissant",
                            Preco = 7.00m,
                            Nota = 4.6,
                            Descricao = "Massa folhada amanteigada.",
                            TempoPreparo = 0,
                            Tipo = "Lanche"
                        },
                        new Alimento
                        {
                            Nome = "Brownie",
                            Preco = 8.50m,
                            Nota = 4.7,
                            Descricao = "Brownie de chocolate intenso.",
                            TempoPreparo = 0,
                            Tipo = "Sobremesa"
                        },
                        new Alimento
                        {
                            Nome = "Espresso",
                            Preco = 5.00m,
                            Nota = 4.9,
                            Descricao = "Dose de café forte e encorpado.",
                            TempoPreparo = 3,
                            Tipo = "Bebida"
                        }
                    }
                };

                var r7 = new Restaurante
                {
                    Nome = "Lanchonete Vegana",
                    Local = "Rua Verde, 88",
                    Tipo = "Vegana",
                    Nota = 4.6,
                    Alimentos = new List<Alimento>
                    {
                        new Alimento
                        {
                            Nome = "Hambúrguer de Grão-de-Bico",
                            Preco = 19.00m,
                            Nota = 4.5,
                            Descricao = "Burger vegan com grão-de-bico e especiarias.",
                            TempoPreparo = 12,
                            Tipo = "Hambúrguer"
                        },
                        new Alimento
                        {
                            Nome = "Wrap de Falafel",
                            Preco = 16.00m,
                            Nota = 4.6,
                            Descricao = "Wrap recheado com falafel crocante.",
                            TempoPreparo = 10,
                            Tipo = "Lanche"
                        },
                        new Alimento
                        {
                            Nome = "Salada Power Bowl",
                            Preco = 22.00m,
                            Nota = 4.7,
                            Descricao = "Mix de folhas, grãos e vegetais.",
                            TempoPreparo = 8,
                            Tipo = "Salada"
                        },
                        new Alimento
                        {
                            Nome = "Smoothie Tropical",
                            Preco = 12.00m,
                            Nota = 4.8,
                            Descricao = "Frutas tropicais batidas.",
                            TempoPreparo = 5,
                            Tipo = "Bebida"
                        },
                        new Alimento
                        {
                            Nome = "Brownie Vegano",
                            Preco = 9.50m,
                            Nota = 4.6,
                            Descricao = "Brownie sem ingredientes de origem animal.",
                            TempoPreparo = 0,
                            Tipo = "Sobremesa"
                        }
                    }
                };

                db.Restaurantes.AddRange(r1, r2, r3, r4, r5, r6, r7);
                db.SaveChanges();
            }
        }
    }
}
