using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Core.Entities
{
    [Table("tbEmpresa")]
    public class Empresa : EntidadeBase
    {
        [Required(ErrorMessage = "Informe o nome da Empresa")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome Fantasia da Empresa")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public bool Ativo { get; set; }

        [DisplayName("Data de Fundação")]
        [Required(ErrorMessage = "Informe a Data de Fundação")]
        public DateTime DataFundacao { get; set; }

    }
}
