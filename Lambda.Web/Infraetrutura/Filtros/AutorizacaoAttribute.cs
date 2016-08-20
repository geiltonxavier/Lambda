using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lambda.Core.Entities.Enum;
using Lambda.Web.Infraetrutura.CustomActionResult;
using Lambda.Web.Infraetrutura.Provider.Abstract;
using Ninject;

namespace Lambda.Web.Infraetrutura.Filtros
{
    public class AutorizacaoAttribute : AuthorizeAttribute
    {
        [Inject]
        public IAutenticacaoProvider AutenticacaoProvider { get; set; }

        private string msgErro;

        private Grupo[] gruposComAcesso;

        public AutorizacaoAttribute(params Grupo[] grupos)
        {
            gruposComAcesso = grupos;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!AutenticacaoProvider.Autenticado)
            {
                msgErro = "Você precisa se autenticar para acessar essa página";
                return false;
            }
            if (!gruposComAcesso.Contains(AutenticacaoProvider.UsuarioAutenticado.Grupo.GetValueOrDefault()) && gruposComAcesso.Length > 0)
            {
                msgErro = "Você não tem permissão para acessar essa página com suas credenciais";
                return false;
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);

            var isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();
            if (isAjaxRequest)
                filterContext.Result = new RedirectResultComStatus(FormsAuthentication.LoginUrl, ((HttpUnauthorizedResult)filterContext.Result).StatusCode);
            filterContext.Controller.TempData["MensagemErro"] = msgErro;
        }
    }
}