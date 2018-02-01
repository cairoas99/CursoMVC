using System.Net;
using System.Web.Mvc;
using Teste1.Application.Applications;
using Teste1.Application.Models;

namespace Teste1.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoApplication _produtoApplication = new ProdutoApplication();
        
        public ActionResult ListarProdutos()
        {
            var response = _produtoApplication.GetProdutos();

            if(response.Status != HttpStatusCode.OK)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.ContentAsString);
            }

            return View("GridProdutos", response.Content);
        }


        public ActionResult CadastarProduto(ProdutoModel produto)
        {
            var response = _produtoApplication.PostProduto(produto);

            if (response.Status != HttpStatusCode.OK)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.ContentAsString);
            }

            return Content(response.Content);
        }
    }
}