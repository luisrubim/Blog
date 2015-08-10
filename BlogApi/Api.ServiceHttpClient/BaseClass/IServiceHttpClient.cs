using Business.Entitie.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceHttpClient
{
    public interface IServiceHttpClient<T> where T : class
    {
        T GetById(Guid id);
        List<T> GetAll();
        T Save(T entity);
        void SetParametros(string url, LoginTokenResult token);
    }
}
