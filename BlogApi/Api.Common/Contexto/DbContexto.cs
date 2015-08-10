using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Common.Contexto
{
    public class DbContexto : DbContext
    {
        public DbContexto(): base("DataContext")
        {

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.SetCommandTimeOut(600);
        }

        public DbContexto(string connection)
        {
            base.Database.Connection.ConnectionString = connection;
            this.SetCommandTimeOut(600);

        }

        public void SetCommandTimeOut(int Timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = Timeout;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Post> Post { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<PostTag> PostTag { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

    }
}
