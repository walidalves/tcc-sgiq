using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class Indicador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndicadorId { get; set; }

        [MaxLength(60)]
        public string Descricao { get; set; }

        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        public int MetricaId { get; set; }

        public virtual List<MetaIndicador> MetasIndicador { get; set; }

        public virtual List<IndicadorProjeto> IndicadoresProjeto { get; set; }

        public Metrica Metrica { get; set; }
    }
}
