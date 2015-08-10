using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;

namespace Api.Common.Factory
{
    public class BusinessLogicFactory<I>
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
