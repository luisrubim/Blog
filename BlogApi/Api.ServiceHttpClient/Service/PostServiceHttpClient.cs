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
    public class PostServiceHttpClient : ServiceHttpClientBase<Post>, IPostServiceHttpClient
    {
        public List<Post> GetLast()
        {
            HttpResponseMessage response = client.GetAsync("api/Post/GetLast?count=5").Result;

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<Post>>().Result.ToList();
            else
                throw new Exception(ReturnErro.GetErro(response));
        }

        public List<Post> Get(int index, int count)
        {
            HttpResponseMessage response = client.GetAsync(string.Format("api/Post/Get?index={0}&count={1}",index,count)).Result;

            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<IEnumerable<Post>>().Result.ToList();
            else
                throw new Exception(ReturnErro.GetErro(response));
        }
    }
}
