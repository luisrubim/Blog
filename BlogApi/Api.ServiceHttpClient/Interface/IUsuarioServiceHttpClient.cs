using Business.Entitie;
using Business.Entitie.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.ServiceHttpClient
{
    public interface IUsuarioServiceHttpClient : IServiceHttpClient<Usuario>
    {
        LoginTokenResult Logar(string email, string senha);
    }
}
