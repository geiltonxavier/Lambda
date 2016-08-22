using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Lambda.Core.Business.Abstract;
using Lambda.Core.DTO;
using Lambda.Web.Infraestrutura.Provider.Abstract;
using Lambda.Web.Infraestrutura.Utils;
using Ninject;

namespace Lambda.Web.Infraestrutura.Provider.Concrete
{
    public class AutenticacaoProvider : IAutenticacaoProvider
    {
        [Inject]
        public IUsuarioBusiness UsuarioBusiness { get; set; }

        [Inject]
        public AutenticacaoModel AutenticacaoModel { get; set; }


        public bool Login(Core.DTO.AutenticacaoModel autenticacaoModel, out string msgErro)
        {
            msgErro = string.Empty;

            var usuario = UsuarioBusiness.Consulta.FirstOrDefault(c => c.Login == autenticacaoModel.Login);

            if (usuario == null || usuario.Senha != autenticacaoModel.Senha)
            {
                msgErro = "Login ou senha incorretos";
                return false;
            }

            autenticacaoModel.Grupo = usuario.Grupo;
            autenticacaoModel.Nome = usuario.Nome;
            autenticacaoModel.UsuarioID = usuario.Id;

            GerarTicketEArmazenarComoCookie(autenticacaoModel);

            return true;
        }

        private void GerarTicketEArmazenarComoCookie(Core.DTO.AutenticacaoModel autenticacaoModel, int expiracaoEmMinutos = 180)
        {
            var ticketEncriptado = gerarTicketEncriptado(autenticacaoModel, expiracaoEmMinutos);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketEncriptado);

            authCookie.Expires = DateTime.Now.AddMinutes(expiracaoEmMinutos);

            HttpContext.Current.Response.Cookies.Add(authCookie);


        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public bool Autenticado
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public Core.DTO.AutenticacaoModel UsuarioAutenticado
        {
            get
            {
                if (Autenticado)
                {
                    var identity = (FormsIdentity)HttpContext.Current.User.Identity;

                    var ticket = identity.Ticket;

                    AutenticacaoModel = Serializador.DeserializarAutenticacaoModel(ticket.UserData);

                    return AutenticacaoModel;
                }
                return null;
            }
        }

        public string gerarTicketEncriptado(Core.DTO.AutenticacaoModel autenticacaoModel, int expiracaoEmMinuto = 180)
        {
            var autenticacaoModelSerializado = Serializador.SerializarAutenticacaoModel(autenticacaoModel);
            var ticket = new FormsAuthenticationTicket(1, autenticacaoModel.Login,
                DateTime.Now, DateTime.Now.AddMinutes(expiracaoEmMinuto), false, autenticacaoModelSerializado,
                FormsAuthentication.FormsCookiePath);
            var ticketEncriptado = FormsAuthentication.Encrypt(ticket);
            return ticketEncriptado;
        }
    }
}