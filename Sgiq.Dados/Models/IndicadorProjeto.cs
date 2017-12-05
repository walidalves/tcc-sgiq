using System.ComponentModel.DataAnnotations;

namespace Sgiq.Dados.Models
{
    public class IndicadorProjeto
    {
        [Key]
        [Required]
        public int IndicadorId { get; set; }

        [Key]
        [Required]
        public int ProjetoId { get; set; }

        public virtual Projeto Projeto { get; set; }

        public virtual Indicador Indicador { get; set; }
    }
}
