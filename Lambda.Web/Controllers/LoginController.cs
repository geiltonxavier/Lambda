using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lambda.Core.DTO;
using Lambda.Web.Infraetrutura.Provider.Abstract;
using Ninject;

namespace Lambda.Web.Controllers
{
    public class LoginController : Controller
    {
        [Inject]
        public IAutenticacaoProvider AutenticacaoProvider { get; set; }
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(AutenticacaoModel autenticacaoModel)
        {
            if (ModelState.IsValid)
            {
                var msgErro = string.Empty;
                if (!AutenticacaoProvider.Login(autenticacaoModel, out msgErro))
                {
                    TempData["MensagemErro"] = msgErro;
                    return View(autenticacaoModel);
                }
                return Redirect("#Empresa");
            }
            return View(autenticacaoModel);
        }

        public ActionResult Sair()
        {
            AutenticacaoProvider.Logout();
            return RedirectToAction("Index");
        }
    }
}