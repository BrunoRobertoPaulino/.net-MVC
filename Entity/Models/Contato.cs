using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? SobreNome { get; set; }
    }
}
