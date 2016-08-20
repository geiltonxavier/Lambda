using System.Data.Entity;
using Lambda.Core.DI;
using Lambda.Core.Repository.Configuration;
using Ninject;
using NUnit.Framework;

namespace Lambda.Teste
{
    public abstract class BaseTeste
    {
        protected IKernel kernel;
        [TestFixtureSetUp]
        public virtual void AntesDeTodosOsTestes()
        {
            kernel = new StandardKernel(new LambdaNinjectModule());
            kernel.Inject(this);
        }

        [SetUp]
        public virtual void AntesDeCadaTeste()
        {
            var labdaContext = kernel.Get<LambdaContext>();

            if (labdaContext.Database.Exists())
            {
                labdaContext.Database.Delete();
            }

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LambdaContext, Core.Migrations.Configuration>());
            using (labdaContext)
            {
                labdaContext.Database.Initialize(true);
            }


        }
    }
}
