using Api.Common.BaseClass;
using Business.Entitie;
using Business.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logic
{
    public class ComentarioBL : BusinessLogicBase<Comentario>, IComentarioBL
    {
        public List<Comentario> GetByPost(Guid id)
        {
            return db.Comentario
                .Include("Usuario")
                .Where(x => x.IdPost == id)
                .ToList();
        }

        public void InserirComentario(Guid idPost,Guid idUsuario,string Mensagem)
        {
            Comentario comentario = new Comentario();
            comentario.IdPost = idPost;
            comentario.Mensagem = Mensagem;
            comentario.IdUsuario = idUsuario;
            comentario.Data = DateTime.Now;

            base.Insert(comentario);
         }
    }
}
