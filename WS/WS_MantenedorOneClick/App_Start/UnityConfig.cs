using Microsoft.Practices.Unity;
using System;
using System.Web.Http;
using Unity.WebApi;
using WS_MantenedorOneClick.Models.Contracts;
using WS_MantenedorOneClick.Models.Repositories;

namespace WS_MantenedorOneClick
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });



        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IMantenedorOcRepository, MantenedorOcRepository>(new PerRequestLifetimeManager());
        }
    }
}