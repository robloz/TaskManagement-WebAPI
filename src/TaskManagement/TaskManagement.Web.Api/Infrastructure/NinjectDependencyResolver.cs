using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using Ninject.Web.Common;
using TaskManagement.Api.Models.Abstract;
using TaskManagement.Common.Concrete;
using TaskManagement.Common.Interface;
using TaskManagement.Data.SqlServer.Concrete;
using TaskManagement.Web.Api.Infrastructure.Identity;

namespace TaskManagement.Web.Api.Infrastructure
{
    /*
    public class WebApiNinjectDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IResolutionRoot resolutionRoot;

        public WebApiNinjectDependencyResolver(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = this.resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return this.resolutionRoot.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.resolutionRoot.GetAll(serviceType, new IParameter[0]).ToList();
        }

        #region IDependencyResolver Members

        public System.Web.Http.Dependencies.IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    */
    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            //System.Web.Http.Dependencies.IDependencyResolver
            _kernel = kernel;

            AddBindings();
            
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IDateTime>().To<DateTimeAdapter>();
            _kernel.Bind<IRepository>().To<EFRepository>();
            _kernel.Bind<IAuthnManager>().To<AuthnManagerIdentity>();

        }

    }
}