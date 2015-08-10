using Api.ServiceHttpClient;
using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using WebApplication.Helpers.Session;
using WebApplication.Models;
using PagedList;

namespace WebApplication.Controllers
{
    public class PostController : Controller
    {
        protected IPostServiceHttpClient servicePost;
        protected IComentarioServiceHttpClient serviceComentario;
        protected IPostTagServiceHttpClient servicePostTag;
        public PostController()
        {
            //Instanciando Servico
            servicePost = ServiceHttpClientFactory<IPostServiceHttpClient>.Instance;
            servicePost.SetParametros(WebConfigurationManager.AppSettings["Url_Api"], GerenciaSession.Token);

            serviceComentario = ServiceHttpClientFactory<IComentarioServiceHttpClient>.Instance;
            serviceComentario.SetParametros(WebConfigurationManager.AppSettings["Url_Api"], GerenciaSession.Token);

            servicePostTag = ServiceHttpClientFactory<IPostTagServiceHttpClient>.Instance;
            servicePostTag.SetParametros(WebConfigurationManager.AppSettings["Url_Api"], GerenciaSession.Token);
        }

        #region Get

        public ActionResult Index(int? pagina)
        {
            //return View(servicePost.GetLast());


            var listaPosts = servicePost.GetAll();
            int paginaTamanho = 4;
            int paginaNumero = (pagina ?? 1);

            return View(listaPosts.ToPagedList(paginaNumero, paginaTamanho));
        }

        public ActionResult Post(Guid id)
        {
            //Trabalhando com ViewModel Exemplo carregando objeto separado
            PostViewModel model = new PostViewModel();
            model.Post = servicePost.GetById(id);
            model.Comentarios = serviceComentario.GetByPost(id);
            model.PostTags = servicePostTag.GetByPost(id);

            return View(model);
        }

        public ActionResult Inserir()
        {
            return View(new Post());
        }

        #endregion

        #region Post

        [HttpPost]
        public ActionResult Inserir(Post entity, FormCollection form)
        {
            Post post = BindObjectPost(entity, form);
            servicePost.Save(post);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Post(PostViewModel entity)
        {
            Comentario comentario = BindObjectComentario(entity);
            serviceComentario.Save(comentario);

            return RedirectToAction("Post", new { guid = entity.Post.Id });
        }

        #endregion     


        #region Métodos

        private Post BindObjectPost(Post entity, FormCollection form)
        {
            entity.Data = DateTime.Now;
            entity.IdUsuario = GerenciaSession.Token.IdUsuario;

            //Exemplo Get FormCollection
            string Tags = form["Tags"];
            foreach(var tgString in Tags.Split(','))
            {
                Tag tag = new Tag { Nome = tgString.ToString() };
                entity.PostTags.Add(new PostTag { Tag = tag });
            }

            return entity;
        }

        private Comentario BindObjectComentario(PostViewModel entity)
        {
            Comentario comentario = new Comentario();
            comentario.Data = DateTime.Now;
            comentario.IdPost = entity.Post.Id;
            comentario.IdUsuario = GerenciaSession.Token.IdUsuario;
            comentario.Mensagem = entity.ComentarioInserir.Mensagem;

            return comentario;
        }

        #endregion
        
    }
}
