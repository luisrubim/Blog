using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceHttpClient.BaseClass
{
    public static class ReturnErro
    {
        public static string GetErro(HttpResponseMessage response)
        {
            var value = response.Content.ReadAsStringAsync().Result;
            var obj = new { message = "", ModelState = new Dictionary<string, string[]>() };
            var x = JsonConvert.DeserializeAnonymousType(value, obj);

            StringBuilder msgRetorno = new StringBuilder();
            foreach (var key in x.ModelState.Values)
                msgRetorno.Append(key[0]);

            return msgRetorno.ToString();
        }
    }
}
