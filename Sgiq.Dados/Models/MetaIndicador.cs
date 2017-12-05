using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class MetaIndicador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MetaIndicadorId { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public int IndicadorId { get; set; }

        [Required]
        public int CondicaoId { get; set; }

        [ForeignKey("CondicaoId")]
        public virtual Condicao Condicao{ get; set; }
    }
}
