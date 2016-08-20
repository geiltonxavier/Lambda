using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Core.Entities
{
    public class Empresa : EntidadeBase
    {
        public string Nome { get; set; }

        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataFundacao { get; set; }

    }
}
