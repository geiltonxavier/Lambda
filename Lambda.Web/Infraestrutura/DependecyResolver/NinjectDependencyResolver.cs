using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Lambda.Core.DI;
using Lambda.Web.Infraestrutura.Provider.Abstract;
using Lambda.Web.Infraestrutura.Provider.Concrete;
using Ninject;

namespace Lambda.Web.Infraestrutura.DependecyResolver
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        public IKernel Kernel { get; private set; }

        public NinjectDependencyResolver()
        {
            Kernel = new StandardKernel(new LambdaNinjectModule());
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
           Kernel.Bind<IAutenticacaoProvider>().To<AutenticacaoProvider>();
        }

    }
}