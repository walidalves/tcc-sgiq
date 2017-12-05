using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public partial class Papel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PapelId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        public List<ParteInteressadaProjeto> PartesInteressadasProjeto { get; set; }
        
    }
}
