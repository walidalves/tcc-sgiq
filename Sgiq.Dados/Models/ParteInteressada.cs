using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        public List<ParteInteressadaProjeto> PartesInteressadasProjeto { get; set; }
    }
}
