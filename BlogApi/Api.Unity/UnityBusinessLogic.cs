using Api.Common.BaseClass;
using Api.Common.Interface;
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
using System.Threading.Tasks;

namespace Api.Unity
{
    public class UnityBusinessLogic
    {
        private UnityBusinessLogic()
        {

        }

        private static IUnityContainer CreateConfiguredUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            #region Business

            container.RegisterType(typeof(IBusinessLogic<>), typeof(BusinessLogicBase<>),
            new Interceptor<TransparentProxyInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());

            container.RegisterType<IUsuarioBL, UsuarioBL>();
            container.RegisterType<IPostBL, PostBL>();
            container.RegisterType<IPostTagBL, PostTagBL>();
            container.RegisterType<IComentarioBL, ComentarioBL>();
            container.RegisterType<ITagBL, TagBL>();
           

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
