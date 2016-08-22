using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lambda.Web.Infraestrutura.Filtros;
using Lambda.Web.Infraestrutura.Provider.Abstract;
using Ninject;

namespace Lambda.Web.Controllers
{

    [Autorizacao]
    public class HomeController : Controller
    {
        [Inject]
        public IAutenticacaoProvider AutenticacaoProvider { get; set; }
        public ActionResult Index()
        {
            @ViewBag.UsuarioLogado = AutenticacaoProvider.UsuarioAutenticado.Nome;
            return View();
        }
    }
}
