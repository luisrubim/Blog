using Business.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication.Models
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public List<PostTag> PostTags { get; set; }

        public Comentario ComentarioInserir { get; set; }

        public string ReturnTag()
        {
            StringBuilder strReturn = new StringBuilder();
            foreach(var item in this.PostTags)
            {
                strReturn.AppendFormat("{0},",item.Tag.Nome);
            }

            if (strReturn.Length > 0)
                return strReturn.ToString().Substring(0, strReturn.ToString().Length - 1);
            return string.Empty;
        }
    }
}