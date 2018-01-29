using System.Collections.Generic;
using Teste1.Domain.Entidades;
using Teste1.Repository.DataBase;

namespace Teste1.Repository.Repositories
{
    public class ProdutoRepository : Execucao
    {
        private static readonly Conexao conexao = new Conexao();

        public ProdutoRepository() : base(conexao)
        {
        }
        public IEnumerable<Produto> GetProdutos()
        {
            ExecuteProcedure("[dbo].[SP_SelProdutos]");

            var produtos = new List<Produto>();

            using (var reader = ExecuteReader())
            {
                while (reader.Read())
                    produtos.Add(new Produto {
                        CodigoProduto = reader.ReadAsInt("CodigoProduto"),
                        Nome = reader.ReadAsString("Nome"),
                        Preco = reader.ReadAsDecimal("Preco"),
                        Estoque = reader.ReadAsInt("Estoque")
                    });

            }
            return produtos;
        }
    }
}
