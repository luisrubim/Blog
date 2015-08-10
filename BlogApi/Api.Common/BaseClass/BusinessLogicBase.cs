using Api.Common.Contexto;
using Api.Common.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Common.BaseClass
{
    public class BusinessLogicBase<T> : IBusinessLogic<T> where T : class
    {

        public DbContexto db;

        public BusinessLogicBase()
        {
                db = new DbContexto();
        }

        #region " Obter "

        public virtual Boolean Exists()
        {
            return Convert.ToBoolean(db.Set<T>().Count());
        }

        public virtual T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public virtual bool Existe(decimal id)
        {
            var x = db.Set<T>().Find(id);

            if (x == null)
                return false;
            else
                return true;
        }

        public virtual List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public IList<T> List(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().Where(where).ToList();
        }

        public IList<T> List(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy)
        {
            return db.Set<T>().Where(where).OrderBy(orderBy).ToList();
        }

        #endregion

        #region " Crud "

        public virtual void Insert(T item)
        {
            Atachar(item);
            db.Set<T>().Add(item);
            db.SaveChanges();
        }

        public virtual void InsertRange(List<T> item)
        {
            db.Set<T>().AddRange(item);
            db.SaveChanges();
        }

        public virtual void Update(T item)
        {
            Atachar(item);
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public virtual void Delete(T item)
        {
            Atachar(item);
            db.Set<T>().Remove(item);
            Save();
        }

        public virtual void Delete(Guid id)
        {
            T entidade = db.Set<T>().Find(id);
            db.Set<T>().Remove(entidade);
            Save();
        }

        #endregion


        void Atachar(T item)
        {
            db.Set<T>().Attach(item);
        }

        public virtual void Save()
        {
            db.SaveChanges();
        }

    }
}
