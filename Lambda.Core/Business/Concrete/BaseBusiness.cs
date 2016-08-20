using Lambda.Core.Business.Abstract;
using Lambda.Core.Entities;
using Lambda.Core.Repository.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Core.Business.Concrete
{
    public class BaseBusiness<T> :IBusiness<T> where T: EntidadeBase
    {
        [Inject]
        public IRepository<T> Repository { get; set; }

        public virtual IQueryable<T> Consulta
        {
            get { return Repository.Consulta; }
        }

        public virtual void Excluir(string id)
        {
            Repository.Excluir(id);
        }

        public virtual void Inserir(T entidade)
        {
            Repository.Inserir(entidade);
        }

        public virtual void Alterar(T entidade)
        {
            Repository.Alterar(entidade);
        }

        public virtual T RetornarPorID(string id)
        {
           return Repository.RetornarPorID(id);
        }
    }
}
