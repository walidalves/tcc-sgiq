using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class Requisito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequisitoId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DtInclusao { get; set; }

        public int ProjetoId { get; set; }

        public int TipoRequisitoId { get; set; }

        public virtual AvaliacaoRequisito AvaliacaoRequisito { get; set; }

        public Projeto Projeto { get; set; }

        public TipoRequisito TipoRequisito { get; set; }

    }
}
