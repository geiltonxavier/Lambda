using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lambda.Core.DTO;

namespace Lambda.Web.Infraestrutura.Provider.Abstract
{
    public interface IAutenticacaoProvider
    {
        bool Login(AutenticacaoModel autenticacaoModel, out string msgErro);

        void Logout();

        bool Autenticado { get; }
        AutenticacaoModel UsuarioAutenticado { get; }

        string gerarTicketEncriptado(AutenticacaoModel autenticacaoModel, int expiracaoEmMinuto = 180);
    }
}