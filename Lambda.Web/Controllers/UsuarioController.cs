using System.Web.Mvc;
using Lambda.Core.Entities.Enum;
using Lambda.Web.Infraetrutura.Filtros;

namespace Lambda.Web.Controllers
{
    public class UsuarioController : Controller
    {
        [Autorizacao(Grupo.Admin)]
        public ActionResult Index()
        {
            return View();
        }
    }
}