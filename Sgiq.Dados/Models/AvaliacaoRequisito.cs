using System;
using System.ComponentModel.DataAnnotations;

namespace Sgiq.Dados.Models
{
    public class AvaliacaoRequisito
    {
        [Key]
        public int RequisitoId { get; set; }

        public DateTime DtAvaliacao { get; set; }

        public int VlrAvaliacao { get; set; }

        public virtual Requisito Requisito { get; set; }
    }
}
