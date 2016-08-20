using Lambda.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Core.Repository.Configuration
{
    public class LambdaContext : DbContext
    {
        public LambdaContext():base("LambdaContext") { }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Empresa> Empresa { get; set; }
    }
}
