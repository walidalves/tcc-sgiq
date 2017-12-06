using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class ParteInteressada
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParteInteressadaId { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(60)]
        public string Email { get; set; }

        [MinLength(8)]
        [MaxLength(12)]
        public string Telefone { get; set; }

        public virtual List<ParteInteressadaProjeto> PartesInteressadasProjeto { get; set; }

        public virtual AvaliacaoProjeto AvaliacaoProjeto { get; set; }
    }
}
