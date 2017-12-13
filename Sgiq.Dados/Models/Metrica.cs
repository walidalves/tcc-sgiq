using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class Metrica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MetricaId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(250)]
        public string Formula { get; set; }

        [Required]
        public int FrequenciaAfericaoId { get; set; }
        public FrequenciaAfericao FrequenciaAfericao { get; set; }

        public virtual List<MedidaMetrica> MedidasMetrica { get; set; }
    }
}
