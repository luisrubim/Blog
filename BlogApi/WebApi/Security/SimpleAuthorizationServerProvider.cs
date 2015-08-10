using Api.Common.Factory;
using Business.Entitie;
using Business.Logic.Interface;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebApi.Security
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        Usuario usuario;

        public SimpleAuthorizationServerProvider()
        {
            usuario = new Usuario();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            usuario = BusinessLogicFactory<IUsuarioBL>.Instance.Logar(context.UserName, context.Password);

            if (usuario == null)
            {
                context.SetError("invalid_grant", "Usuário ou senha incorreta.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));

            context.Validated(identity);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            context.AdditionalResponseParameters.Add("IdUsuario", usuario.Id);
            context.AdditionalResponseParameters.Add("NomeUsuario", usuario.Nome);

            return Task.FromResult<object>(null);
        }
    }
}