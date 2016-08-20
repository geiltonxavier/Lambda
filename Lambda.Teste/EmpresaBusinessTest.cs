using System;
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
                DataCriacao = new DateTime(2016, 08, 16),
                Ativo = false
            };
            //Ações
            empresaBusiness.Inserir(empresa);

           

            //Assertivas
            var empresaPersistida = empresaBusiness.RetornarPorID(empresa.Id);
            Assert.IsNotNull(empresaPersistida);
            Assert.AreEqual(empresa.DataFundacao, empresaPersistida.DataFundacao);
          


        }
    }
}
