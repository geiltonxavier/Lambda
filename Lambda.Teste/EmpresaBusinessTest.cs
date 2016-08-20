using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lambda.Core.Business.Abstract;
using Lambda.Core.Entities;
using Ninject;
using NUnit.Framework;

namespace Lambda.Teste
{
    [TestFixture]
    public class EmpresaBusinessTest : BaseTeste
    {
        [Test]
        public void PodeInserirEmpresaTest()
        {
            //Ambiente
            var empresaBusiness = kernel.Get<IBusiness<Empresa>>();
            var empresa = new Empresa()
            {
                Nome = "Empresa A",
                NomeFantasia = "Comercial A",
                CNPJ = "74846605000134",
                Telefone = "123456789",
                DataCriacao = new DateTime(2016,19,8),
                Ativo = false
            };
            //Assertivas
            empresaBusiness.Inserir(empresa);

            //Açãos


        }
    }
}
