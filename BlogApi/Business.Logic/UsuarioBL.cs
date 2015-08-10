using Api.Common.BaseClass;
using Business.Entitie;
using Business.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logic
{
    public class UsuarioBL : BusinessLogicBase<Usuario>, IUsuarioBL
    {
        public Usuario Logar(string email, string password)
        {
            return db.Usuario
                .Where(us => us.Email.Equals(email) && 
                       us.Senha.Equals(password))
                .FirstOrDefault();
        }
    }
}
