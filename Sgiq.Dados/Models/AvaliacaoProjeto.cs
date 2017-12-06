using System;
using System.ComponentModel.DataAnnotations;

namespace Sgiq.Dados.Models
{
    public class AvaliacaoProjeto
    {
        [Key]
        public int ProjetoId { get; set; }

        [Required]
        public string Chave { get; set; }

        public DateTime DtAvaliacao { get; set; }

        public int VlrAvaliacao { get; set; }

        public int ParteInteressadaId { get; set; }

        public virtual Projeto Projeto { get; set; }

        public virtual ParteInteressada ParteInteressada { get; set; }

    }
}
