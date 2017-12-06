using System.ComponentModel.DataAnnotations;

namespace Sgiq.Dados.Models
{
    public class MedidaMetrica
    {
        [Key]
        [Required]
        public int MedidaId { get; set; }

        [Key]
        [Required]
        public int MetricaId { get; set; }

        public virtual Medida Medida { get; set; }

        public virtual Metrica Metrica { get; set; }
    }
}
