using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teste1.Domain.Entidades;
using Teste1.Repository.Repositories;

namespace Teste1.Api.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

        
        public IHttpActionResult GetProdutos()
        {
            try
            {
                return Ok(_produtoRepository.GetProdutos());
            }
            catch
            {
                return BadRequest("Erro ao listar produtos");
            }
        }

        [HttpPost, Route("cadastraProduto")]
        public IHttpActionResult PostProduto(Produto produto)
        {
            try
            {
                var retorno = _produtoRepository.CadastraProduto(produto);
                if (retorno != null)
                    return BadRequest(retorno);
                else
                    return Ok("Produto cadastrado com sucesso!");
            }
            catch
            {
                return BadRequest(("Algo deu errado."));
            }

        }
    }
}