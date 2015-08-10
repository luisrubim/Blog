using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Common.Interface
{
    public interface IBusinessLogic<T> where T : class
    {

        #region " Get "

        T GetById(Guid id);

        Boolean Exists();
        bool Existe(decimal id);

        List<T> GetAll();

        IList<T> List(Expression<Func<T, bool>> where);
        IList<T> List(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy);

        #endregion

        #region " Cruds "

        //void Save(T entity);
        void Insert(T entity);
        void InsertRange(List<T> item);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Guid Id);
        void Save();

        #endregion

    }
}
