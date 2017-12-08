using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class Medida
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedidaId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        public int TipoDadoId { get; set; }

        public TipoDado TipoDado { get; set; }

        public decimal VlrMinimo { get; set; }

        public decimal VlrMaximo { get; set; }

        public virtual List<MedidaMetrica> MedidasMetrica { get; set; }

        public virtual List<Medicao> Medicoes { get; set; }
    }
}
