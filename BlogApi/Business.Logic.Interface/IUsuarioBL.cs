using Api.Common.Interface;
using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logic.Interface
{
    public interface IUsuarioBL : IBusinessLogic<Usuario>
    {
        Usuario Logar(string email, string password);

    }
}
