using Lambda.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Core.Entities
{
    [Table("tbUsuario")]
    public class Usuario : EntidadeBase
    {
        [Required(ErrorMessage="Informe o nome")]
        [StringLength(100, ErrorMessage="Tamanho máximo excedido")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(100, ErrorMessage = "Tamanho máximo excedido")]
        [EmailAddress(ErrorMessage="Informe um email válido")]
        [Display(Name = "Email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [StringLength(50, ErrorMessage = "Tamanho máximo excedido")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Grupo Grupo { get; set; }


    }
}
