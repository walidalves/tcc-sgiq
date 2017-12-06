using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class TipoRequisito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoRequisitoId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        public List<Requisito> Requisitos { get; set; }
    }
}
