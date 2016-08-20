using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lambda.Core.Business.Abstract;
using Lambda.Core.Entities;

namespace Lambda.Core.Business.Concrete
{
    public class UsuarioBusiness : BaseBusiness<Usuario>, IUsuarioBusiness
    {
        public override void Inserir(Usuario usuario)
        {
            if (Consulta.Any(u => u.Login == usuario.Login))
            {
               throw new InvalidOperationException("Esse login já está cadastrado, não é possivel inserir usuário com o mesmo login.");
            }
            base.Inserir(usuario);
        }
    }
}
