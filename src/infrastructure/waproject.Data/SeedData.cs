using waproject.Data.Contexts;
using waproject.Domain.Entities;

namespace waproject.Data
{
    public static class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            var produto1 = new Produto
            {
                Nome = "Motosserra à Gasolina",
                Descricao = "Projetada para oferecer o melhor rendimento nos trabalhos mais intensos, a motosserra é ergonômica, movida a gasolina e com baixo peso atendendo as necessidades das mais variadas aplicações, sendo indicada para podas, corte de árvores de médio porte, reflorestamentos, desgalhamentos e trabalhos intensos e contínuos.",
                Valor = 1299.90M
            };

            var produto2 = new Produto
            {
                Nome = "Jogo de Ferramentas Profissionais com 150 Peças e Maleta",
                Descricao = "Jogo de ferramentas produzido em cromo vanádio, proporcionando qualidade e durabilidade.",
                Valor = 799.90M
            };

            var produto3 = new Produto
            {
                Nome = "Jogo 100 peças Chaves de Fenda/ Phillips e Bits",
                Descricao = "O Jogo com 100 peças de Chaves de Fenda e Phillips FORTG PRO FG8193 é composto por 23 chaves de fenda/phillips, 01 chave com catraca, 02 chaves offset, 08 chaves de precisão, 06 bits soquetes e 60 bits de 25mm.",
                Valor = 189.90M
            };

            var pedido1 = new Pedido
            {
                DataCriacao = DateTime.Now,
                DataEntregaRealizada = DateTime.Now.AddDays(2),
                Endereco = "Avenida Alagoas, 1193, Jardim Paulista - Franca-SP",
                NumeroIdentificacao = "29b99d08-0a36-4d01-90d0-74039715f689",
            };

            var pedido2 = new Pedido
            {
                DataCriacao = DateTime.Now.AddDays(-2),
                DataEntregaRealizada = DateTime.Now.AddDays(4),
                Endereco = "R. Espírito Santo, 497 - Centro, Juiz de Fora - MG",
                NumeroIdentificacao = "7b36a442-421f-4b02-bca2-34e9c7c75857",
            };

            var pedido3 = new Pedido
            {
                DataCriacao = DateTime.Now.AddDays(3),
                DataEntregaRealizada = DateTime.Now.AddDays(8),
                Endereco = "Av. Barão do Rio Branco, 2572 - Centro, Juiz de Fora - MG",
                NumeroIdentificacao = "6ad01cd6-d25c-4f0c-943f-3a1be34246df",
            };

            var pedidoItem1 = new List<PedidoItem>
            {
                new PedidoItem
                {
                    Pedido = pedido1,
                    Produto = produto1
                },
                new PedidoItem
                {
                    Pedido = pedido1,
                    Produto = produto2
                },
            };

            var pedidoItem2 = new List<PedidoItem>
            {
                new PedidoItem
                {
                    Pedido = pedido2,
                    Produto = produto3
                }
            };

            var pedidoItem3 = new List<PedidoItem>
            {
                new PedidoItem
                {
                    Pedido = pedido3,
                    Produto = produto1
                },
                new PedidoItem
                {
                    Pedido = pedido3,
                    Produto = produto2
                },
                new PedidoItem
                {
                    Pedido = pedido3,
                    Produto = produto3
                }
            };

            var equipe1 = new Equipe
            {
                Nome = "Sedex",
                Descricao = "O SEDEX é um serviço da Empresa Brasileira de Correios e Telégrafos de despacho expresso de documentos e encomendas.",
                PlacaVeiculo = "KAZ-3700",
                Pedidos = new List<Pedido>
                {
                    pedido2,
                    pedido3
                }
            };

            var equipe2 = new Equipe
            {
                Nome = "Azul Cargo",
                Descricao = "A Azul Cargo é um serviço de logística pertencente à Azul Linhas Aéreas Brasileiras, que opera desde 2009 garantindo pontualidade, eficiência e qualidade no transporte de encomendas.",
                PlacaVeiculo = "JST-3285",
                Pedidos = new List<Pedido>
                {
                    pedido1
                }
            };

            if (!context.Produtos.Any())
            {
                await context.Produtos.AddRangeAsync(
                    produto1,
                    produto2,
                    produto3
                );
            }

            if (!context.Pedidos.Any())
            {
                await context.Pedidos.AddRangeAsync(
                    pedido1,
                    pedido2,
                    pedido3
                );
            }

            if (!context.PedidoItems.Any())
            {
                await context.PedidoItems.AddRangeAsync(pedidoItem1);
                await context.PedidoItems.AddRangeAsync(pedidoItem2);
                await context.PedidoItems.AddRangeAsync(pedidoItem3);
            }

            if (!context.Equipes.Any())
            {
                await context.Equipes.AddRangeAsync(
                    equipe1,
                    equipe2
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
