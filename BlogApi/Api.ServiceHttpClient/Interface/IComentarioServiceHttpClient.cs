using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceHttpClient
{
    public interface IComentarioServiceHttpClient : IServiceHttpClient<Comentario>
    {
        List<Comentario> GetByPost(Guid guid);
    }
}
