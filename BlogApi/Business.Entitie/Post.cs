using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entitie
{
    [Table("Post")]
    public class Post
    {
        public Post()
        {
            this.Comentarios = new HashSet<Comentario>();
            this.PostTags = new HashSet<PostTag>(); 
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Corpo { get; set; }

        public virtual ICollection<Comentario> Comentarios { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; }

    }
}
