using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entitie
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

    }
}
