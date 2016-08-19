using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Lambda.Core.Repository.Concrete;
using Lambda.Core.Repository.Abstract;

namespace Lambda.Core.DI
{
    public class LambdaNinjectModule : NinjectModule
    {
        public override void Load()
        {
            AddBindingGenerics();
        }

        public void AddBindingGenerics(){

            Kernel.Bind( c => c.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterfaces());

            Kernel.Bind(typeof(IRepository<>)).To(typeof(BaseRepository<>));

        }
    }
}
