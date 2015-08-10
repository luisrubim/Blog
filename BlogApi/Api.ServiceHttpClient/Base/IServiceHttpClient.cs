using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ServiceHttpClient
{
    public interface IServiceHttpClient<T> where T : class
    {
        T GetById(int id);
        T GetById(decimal id);
        List<T> GetAll();
        void Insert(T entity);
        void InsertRange(List<T> item);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int Id);
        void Delete(decimal Id);
    }
}
