using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class Atividade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtividadeId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtInicioPrevista { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtTerminoPrevista { get; set; }

        public int ProjetoId { get; set; }

    }
}
