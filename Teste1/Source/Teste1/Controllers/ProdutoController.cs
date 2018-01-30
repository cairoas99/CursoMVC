using System.Net;
using System.Web.Mvc;
using Teste1.Application.Applications;

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

            return View("", response.Content);
        }
    }
}