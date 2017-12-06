using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class FrequenciaAfericao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FrequenciaAfericaoId { get; set; }

        [Required]
        [MaxLength(45)]
        public string Nome { get; set; }

        public List<Metrica> Metricas { get; set; }

    }
}
