using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lambda.Core.DI;
using Lambda.Web.Infraetrutura.Provider.Abstract;
using Lambda.Web.Infraetrutura.Provider.Concrete;
using Ninject;

namespace Lambda.Web.Infraetrutura.DependecyResolver
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