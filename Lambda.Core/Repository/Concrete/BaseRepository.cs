using Lambda.Core.Entities;
using Lambda.Core.Repository.Abstract;
using Lambda.Core.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Core.Repository.Concrete
{
    class BaseRepository<T> : IRepository<T> where T : EntidadeBase
    {
        protected LambdaContext Context;

        public BaseRepository(LambdaContext contextParam)
        {
            Context = contextParam;
        }

        public IQueryable<T> Consulta
        {
            get
            {
                return from c in Context.Set<T>() select c;
            }
        }

        public void Excluir(string id)
        {
            var entidade = Consulta.First(c => c.Id == id);
            Context.Entry(entidade).State = EntityState.Deleted;
            Context.SaveChanges();

        }

        public void Inserir(T entidade)
        {
            entidade.DataCriacao = DateTime.Now;
            Context.Entry(entidade).State = EntityState.Added;
            Context.SaveChanges();
        }

        public void Alterar(T entidade)
        {
            Context.Entry(entidade).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public T RetornarPorID(string id)
        {
            return Consulta.FirstOrDefault(c => c.Id == id);
        }
    }
}
