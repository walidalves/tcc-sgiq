using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public partial class TipoDado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoDadoId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        List<Medida> Medidas { get; set; }
    }
}
