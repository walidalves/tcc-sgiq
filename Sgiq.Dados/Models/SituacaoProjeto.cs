using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class SituacaoProjeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SituacaoProjetoId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        public List<Projeto> Projetos { get; set; }
    }
}
