using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Core.Entities
{
    public class EntidadeBase
    {
        [Key]
        [MaxLength(40)]
        public string Id { get; set; }

        public EntidadeBase()
        {
            Id = Guid.NewGuid().ToString();
        }

        public DateTime DataCriacao { get; set; }



    }
}
