using System;
using System.Linq;
using Lambda.Core.Business.Abstract;
using Lambda.Core.Entities;
using Lambda.Core.Entities.Enum;
using Ninject;
using NUnit.Framework;

namespace Lambda.Teste
{
    [TestFixture]
    public class UsuarioBusinessTest : BaseTeste
    {
        [Test]
        public void PodeInserirUsuarioTeste()
        {
            //Ambiente
            var usuarioBusiness = kernel.Get<IBusiness<Usuario>>();


            //Ação
            var usuario = new Usuario()
            {
                Nome = "Geilton Xavier",
                Login = "geilton@live.com",
                Senha = "123456",
                Grupo = Grupo.Admin

            };
            usuarioBusiness.Inserir(usuario);

            //Assertivas
            var usuarioPersistido = usuarioBusiness.RetornarPorID(usuario.Id);
            Assert.IsNotNull(usuarioPersistido);
            Assert.AreEqual(usuario.Grupo, usuarioPersistido.Grupo);
            Assert.AreEqual(usuario.Login, usuarioPersistido.Login);

        }

        [Test]
        public void NaoPodeInserirUsuarioComMesmoLogin()
        {
            //Ambiente
            var usuarioBusiness = kernel.Get<IBusiness<Usuario>>();


            //Ação
            #region Inserir Primeiro Usuario
            var usuario = new Usuario()
            {
                Nome = "Geilton Xavier",
                Login = "geilton@live.com",
                Senha = "123456",
                Grupo = Grupo.Admin

            };
            usuarioBusiness.Inserir(usuario);
            #endregion

            //Ação
            #region Não pode Inserir Segundo Usuario

            var usuario2 = new Usuario()
            {
                Nome = "Jackson Xavier",
                Login = "geilton@live.com",
                Senha = "654321",
                Grupo = Grupo.Usuario

            };

            #endregion

           
            //Assertivas
            Assert.Throws<InvalidOperationException>(() => usuarioBusiness.Inserir(usuario2));
            var usuariosPersistidos = usuarioBusiness.Consulta.Count();
            Assert.AreEqual(1, usuariosPersistidos);
            var usuarioPersistido = usuarioBusiness.RetornarPorID(usuario2.Id);
            Assert.IsNull(usuarioPersistido);






        }
    }
}
