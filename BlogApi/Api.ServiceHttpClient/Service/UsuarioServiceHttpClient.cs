using Api.ServiceHttpClient.BaseClass;
using Business.Entitie;
using Business.Entitie.Infra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Api.ServiceHttpClient
{
    public class UsuarioServiceHttpClient : ServiceHttpClientBase<Usuario>, IUsuarioServiceHttpClient
    {
        public virtual LoginTokenResult Logar(string email, string senha)
        {
            LoginTokenResult token = GetLoginToken(client, email, senha);
            return token;
        }

        private static LoginTokenResult GetLoginToken(HttpClient client, string username, string password)
        {
            HttpResponseMessage response =
              client.PostAsync("Token",
                new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                  username,
                  password), Encoding.UTF8,
                  "application/x-www-form-urlencoded")).Result;

            string resultJSON = response.Content.ReadAsStringAsync().Result;
            object result = JsonConvert.DeserializeObject<object>(resultJSON);
            LoginTokenResult login = JsonConvert.DeserializeObject<LoginTokenResult>(resultJSON);

            return login;
        }
    }
}
