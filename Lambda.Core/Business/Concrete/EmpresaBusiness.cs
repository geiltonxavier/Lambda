using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lambda.Core.Business.Abstract;
using Lambda.Core.Entities;

namespace Lambda.Core.Business.Concrete
{
    class EmpresaBusiness : BaseBusiness<Empresa>, IEmpresaBusiness
    {
        public override void Inserir(Empresa empresa)
        {
            if (Consulta.Any(u => u.CNPJ == empresa.CNPJ))
            {
                throw new InvalidOperationException("CNPJ já está cadastrado, não é possivel cadastrar o mesmo CNPJ.");
            }
            base.Inserir(empresa);
        }

    }
}
