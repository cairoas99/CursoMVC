﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using Teste1.Repository.Repositories;

namespace Teste1.Api.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

        public IHttpActionResult GetProdutos()
        {
            return Ok(_produtoRepository.GetProdutos());
        }
    }
}