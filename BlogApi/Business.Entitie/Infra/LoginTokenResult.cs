using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entitie.Infra
{
    public class LoginTokenResult
    {

        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }

        [JsonProperty(PropertyName = "IdUsuario")]
        public Guid IdUsuario { get; set; }


        [JsonProperty(PropertyName = "NomeUsuario")]
        public string NomeUsuario { get; set; }

    }
}
