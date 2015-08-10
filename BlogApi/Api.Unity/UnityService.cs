using Api.Common.BaseClass;
using Api.Common.Interface;
using Api.ServiceHttpClient;
using Business.Entitie;
using Business.Logic;
using Business.Logic.Interface;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Unity
{
    public class UnityService
    {
        private UnityService()
        {

        }

        private static IUnityContainer CreateConfiguredUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            #region Business

            container.RegisterType(typeof(IServiceHttpClient<>), typeof(ServiceHttpClientBase<>),
            new Interceptor<TransparentProxyInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());

            container.RegisterType<IUsuarioServiceHttpClient, UsuarioServiceHttpClient>();
            container.RegisterType<IPostServiceHttpClient, PostServiceHttpClient>();
            container.RegisterType<IPostTagServiceHttpClient, PostTagServiceHttpClient>();
            container.RegisterType<IComentarioServiceHttpClient, ComentarioServiceHttpClient>();
            container.RegisterType<ITagServiceHttpClient, TagServiceHttpClient>();
           

            #endregion


            return container;
        }

        internal static void Initialize()
        {
            UnityServiceLocator locator = new UnityServiceLocator(CreateConfiguredUnityContainer());
            ServiceLocator.SetLocatorProvider(() => locator);
        }
    }
}
