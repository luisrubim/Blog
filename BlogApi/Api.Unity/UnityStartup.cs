using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Unity
{
    public class UnityStartup
    {
        protected UnityStartup()
        {

        }

        public static void Initialize()
        {
            UnityBusinessLogic.Initialize();
        }

        public static void InitializeService()
        {
            UnityService.Initialize();
        }
    }
}
