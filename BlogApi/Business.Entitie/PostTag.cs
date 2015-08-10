using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entitie
{
    [Table("PostTag")]
    public class PostTag
    {
        [Key]
        public Guid Id { get; set; }

        public Guid IdPost { get; set; }
        [ForeignKey("IdPost")]
        public virtual Post Post { get; set; }

        public Guid IdTag { get; set; }
        [ForeignKey("IdTag")]
        public virtual Tag Tag { get; set; }

    }
}
