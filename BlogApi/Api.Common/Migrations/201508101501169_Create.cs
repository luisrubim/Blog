namespace Api.Common.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdPost = c.Guid(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdUsuario = c.Guid(nullable: false),
                        Mensagem = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.IdPost)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdPost)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Data = c.DateTime(nullable: false),
                        IdUsuario = c.Guid(nullable: false),
                        Titulo = c.String(nullable: false),
                        Corpo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.PostTag",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdPost = c.Guid(nullable: false),
                        IdTag = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.IdPost)
                .ForeignKey("dbo.Tag", t => t.IdTag)
                .Index(t => t.IdPost)
                .Index(t => t.IdTag);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentario", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Post", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.PostTag", "IdTag", "dbo.Tag");
            DropForeignKey("dbo.PostTag", "IdPost", "dbo.Post");
            DropForeignKey("dbo.Comentario", "IdPost", "dbo.Post");
            DropIndex("dbo.PostTag", new[] { "IdTag" });
            DropIndex("dbo.PostTag", new[] { "IdPost" });
            DropIndex("dbo.Post", new[] { "IdUsuario" });
            DropIndex("dbo.Comentario", new[] { "IdUsuario" });
            DropIndex("dbo.Comentario", new[] { "IdPost" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Tag");
            DropTable("dbo.PostTag");
            DropTable("dbo.Post");
            DropTable("dbo.Comentario");
        }
    }
}
