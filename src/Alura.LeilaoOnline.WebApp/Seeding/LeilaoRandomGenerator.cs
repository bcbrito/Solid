using System;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Seeding
{
    public class LeilaoRandomGenerator
    {
        Random random;
        Categoria[] categorias = new Categoria[6]
        {
            new Categoria() { Descricao = "Diversão e Jogos", Imagem = "images/jogos.png" },
            new Categoria() { Descricao = "Carros Antigos", Imagem = "images/carros.png" },
            new Categoria() { Descricao = "Obras de Arte", Imagem = "images/artes.png" },
            new Categoria() { Descricao = "Imóveis", Imagem = "images/imoveis.png" },
            new Categoria() { Descricao = "Eletrônicos", Imagem = "images/technology.png" },
            new Categoria() { Descricao = "Itens de Colecionador", Imagem = "images/colecionador.png" },
        };

        public LeilaoRandomGenerator(Random random)
        {
            this.random = random;
        }

        private Categoria CategoriaQualquer()
        {
            var indiceAleatorio = random.Next(0,5);
            return categorias[indiceAleatorio];
        }

        private DateTime DataAleatoria()
        {
            int diasAleatorios = random.Next(1,100);
            return DateTime.Now.AddDays(-diasAleatorios);
        }

        public Leilao NovoLeilao
        {
            get
            {
                var leilao = new Leilao();
                // leilao.Id = random.Next(); será definido no loop de geração
                leilao.Categoria = CategoriaQualquer();
                leilao.Titulo = $"{leilao.Categoria.Descricao} - Lote nº {random.Next(500)}";
                leilao.Descricao = $"{leilao.Titulo}. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut consequat semper viverra nam libero justo laoreet. Ut placerat orci nulla pellentesque dignissim enim sit amet. Cras semper auctor neque vitae. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Penatibus et magnis dis parturient montes nascetur ridiculus. Bibendum enim facilisis gravida neque convallis. At risus viverra adipiscing at in tellus integer feugiat scelerisque. Turpis egestas pretium aenean pharetra magna ac. Suspendisse ultrices gravida dictum fusce ut. Mauris vitae ultricies leo integer. Senectus et netus et malesuada fames ac turpis egestas. Libero volutpat sed cras ornare. Tristique senectus et netus et malesuada fames ac." ;
                leilao.Situacao = this.SituacaoAleatoria();
                if (leilao.Situacao != SituacaoLeilao.Rascunho)
                {
                    leilao.Inicio = this.DataAleatoria();
                }
                if (leilao.Situacao == SituacaoLeilao.Finalizado)
                {
                    var dataAnterior = DateTime.Now.AddDays(-random.Next(10));
                    leilao.Termino = leilao.Inicio.Value.CompareTo(dataAnterior) > 0 ? dataAnterior : leilao.Inicio.Value;
                }
                leilao.IdCategoria = leilao.Categoria.Id;
                return leilao;
            }
        }

        private SituacaoLeilao SituacaoAleatoria()
        {
            int index = random.Next(0, 3);
            var values = Enum.GetValues(typeof(SituacaoLeilao));
            return (SituacaoLeilao)values.GetValue(index);
        }
    }
}