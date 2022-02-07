using waproject.Data.Contexts;
using waproject.Domain.Entities;

namespace waproject.Data
{
    public static class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            var produto1 = new Product
            {
                Name = "Motosserra à Gasolina",
                Description = "Projetada para oferecer o melhor rendimento nos trabalhos mais intensos, a motosserra é ergonômica, movida a gasolina e com baixo peso atendendo as necessidades das mais variadas aplicações, sendo indicada para podas, corte de árvores de médio porte, reflorestamentos, desgalhamentos e trabalhos intensos e contínuos.",
                Price = 1299.90M
            };

            var produto2 = new Product
            {
                Name = "Jogo de Ferramentas Profissionais com 150 Peças e Maleta",
                Description = "Jogo de ferramentas produzido em cromo vanádio, proporcionando qualidade e durabilidade.",
                Price = 799.90M
            };

            var produto3 = new Product
            {
                Name = "Jogo 100 peças Chaves de Fenda/ Phillips e Bits",
                Description = "O Jogo com 100 peças de Chaves de Fenda e Phillips FORTG PRO FG8193 é composto por 23 chaves de fenda/phillips, 01 chave com catraca, 02 chaves offset, 08 chaves de precisão, 06 bits soquetes e 60 bits de 25mm.",
                Price = 189.90M
            };

            var pedido1 = new Order
            {
                CreatedAt = DateTime.Now,
                DeliveredAt = DateTime.Now.AddDays(2),
                Address = "Avenida Alagoas, 1193, Jardim Paulista - Franca-SP",
                IdentificationNumber = "29b99d08-0a36-4d01-90d0-74039715f689",
            };

            var pedido2 = new Order
            {
                CreatedAt = DateTime.Now.AddDays(-2),
                DeliveredAt = DateTime.Now.AddDays(4),
                Address = "R. Espírito Santo, 497 - Centro, Juiz de Fora - MG",
                IdentificationNumber = "7b36a442-421f-4b02-bca2-34e9c7c75857",
            };

            var pedido3 = new Order
            {
                CreatedAt = DateTime.Now.AddDays(3),
                DeliveredAt = DateTime.Now.AddDays(8),
                Address = "Av. Barão do Rio Branco, 2572 - Centro, Juiz de Fora - MG",
                IdentificationNumber = "6ad01cd6-d25c-4f0c-943f-3a1be34246df",
            };

            var pedidoItem1 = new List<OrderItem>
            {
                new OrderItem
                {
                    Order = pedido1,
                    Product = produto1
                },
                new OrderItem
                {
                    Order = pedido1,
                    Product = produto2
                },
            };

            var pedidoItem2 = new List<OrderItem>
            {
                new OrderItem
                {
                    Order = pedido2,
                    Product = produto3
                }
            };

            var pedidoItem3 = new List<OrderItem>
            {
                new OrderItem
                {
                    Order = pedido3,
                    Product = produto1
                },
                new OrderItem
                {
                    Order = pedido3,
                    Product = produto2
                },
                new OrderItem
                {
                    Order = pedido3,
                    Product = produto3
                }
            };

            var equipe1 = new Carrier
            {
                Name = "Sedex",
                Description = "O SEDEX é um serviço da Empresa Brasileira de Correios e Telégrafos de despacho expresso de documentos e encomendas.",
                VehiclePlate = "KAZ-3700",
                Orders = new List<Order>
                {
                    pedido2,
                    pedido3
                }
            };

            var equipe2 = new Carrier
            {
                Name = "Azul Cargo",
                Description = "A Azul Cargo é um serviço de logística pertencente à Azul Linhas Aéreas Brasileiras, que opera desde 2009 garantindo pontualidade, eficiência e qualidade no transporte de encomendas.",
                VehiclePlate = "JST-3285",
                Orders = new List<Order>
                {
                    pedido1
                }
            };

            if (!context.Products.Any())
            {
                await context.Products.AddRangeAsync(
                    produto1,
                    produto2,
                    produto3
                );
            }

            if (!context.Orders.Any())
            {
                await context.Orders.AddRangeAsync(
                    pedido1,
                    pedido2,
                    pedido3
                );
            }

            if (!context.OrderItems.Any())
            {
                await context.OrderItems.AddRangeAsync(pedidoItem1);
                await context.OrderItems.AddRangeAsync(pedidoItem2);
                await context.OrderItems.AddRangeAsync(pedidoItem3);
            }

            if (!context.Carriers.Any())
            {
                await context.Carriers.AddRangeAsync(
                    equipe1,
                    equipe2
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
