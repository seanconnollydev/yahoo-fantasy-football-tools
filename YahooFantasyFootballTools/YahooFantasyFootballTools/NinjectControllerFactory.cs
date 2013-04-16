using System;
using System.Web.Mvc;
using Fantasizer;
using Ninject;

namespace YahooFantasyFootballTools
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;

        public NinjectControllerFactory(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) _kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IUserTokenStore>()
                   .ToMethod(context => new SessionStateUserTokenStore(System.Web.HttpContext.Current.Session));

            _kernel.Bind<IFantasizerService>()
                   .ToMethod(
                       context =>
                       ServiceFactory.CreateFantasizerClient(Configuration.ConsumerKey, Configuration.ConsumerSecret,
                                                             _kernel.Get<IUserTokenStore>()));
        }
    }
}