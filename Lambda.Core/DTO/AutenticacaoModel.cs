using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Lambda.Core.Entities.Enum;

namespace Lambda.Core.DTO
{
    [Serializable]
    public class AutenticacaoModel
    {
        [Required(ErrorMessage = "Login é obrigatório")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Grupo? Grupo { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Nome { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UsuarioID { get; set; }
    }
}
