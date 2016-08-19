using Lambda.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Core.Repository.Abstract
{
    public interface IRepository<T> where T : EntidadeBase
    {
        IQueryable<T> Consulta { get; }

        void Excluir(string id);

        void Inserir(T entidade);

        void Alterar(T entidade);

        T RetornarPorID(string id);




    }
}
