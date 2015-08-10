using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceHttpClient
{
    public interface IPostTagServiceHttpClient : IServiceHttpClient<PostTag>
    {
        List<PostTag> GetByPost(Guid idPost);
    }
}
