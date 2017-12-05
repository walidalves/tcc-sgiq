using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class Medicao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicaoId { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DtInclusao { get; set; }

        [Required]
        public int MedidaId { get; set; }

        [Required]
        public int ProjetoId { get; set; }
    }
}
