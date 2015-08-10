using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceHttpClient
{
    public class ServiceHttpClientFactory<I>
    {
        public static I Instance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<I>();
            }
        }
    }
}
