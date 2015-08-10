using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceHttpClient
{
    public interface IPostServiceHttpClient : IServiceHttpClient<Post>
    {
        List<Post> GetLast();
        List<Post> Get(int index, int count);
    }
}
