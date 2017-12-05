using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class ParteInteressadaProjeto
    {
        [Key, Column(Order = 0)]
        [Required]
        public int ProjetoId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        public int ParteInteressadaId { get; set; }

        public int PapelId { get; set; }

        public Projeto Projeto { get; set; }

        public ParteInteressada ParteInteressada { get; set; }

        [ForeignKey("PapelId")]
        public Papel Papel { get; set; }
    }
}
