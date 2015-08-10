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
    public class PostTagServiceHttpClient : ServiceHttpClientBase<PostTag>, IPostTagServiceHttpClient
    {
        public List<PostTag> GetByPost(Guid idPost)
        {
            HttpResponseMessage response = client.GetAsync(string.Format("api/PostTag/GetByPost/{0}", idPost)).Result;

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<PostTag>>().Result.ToList();
            else
                throw new Exception(ReturnErro.GetErro(response));
        }

    }
}
