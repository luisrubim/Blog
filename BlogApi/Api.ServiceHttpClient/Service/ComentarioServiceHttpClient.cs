using Api.ServiceHttpClient.BaseClass;
using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceHttpClient
{
    public class ComentarioServiceHttpClient : ServiceHttpClientBase<Comentario>, IComentarioServiceHttpClient
    {
        public List<Comentario> GetByPost(Guid guid)
        {
            HttpResponseMessage response = client.GetAsync(string.Format("api/Comentario/GetByPost?guid={0}", guid)).Result;

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<Comentario>>().Result.ToList();
            else
                throw new Exception(ReturnErro.GetErro(response));
        }
    }
}
