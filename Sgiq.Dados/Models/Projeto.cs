using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sgiq.Dados.Models
{
    public class Projeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(250)]
        public string Descricao { get; set; }

        //[Required]
        //[Column(TypeName  = "datetime")]
        //public DateTime DtInicioPrevista { get; set; }

        //[Required]
        //[Column(TypeName = "datetime")]
        //public DateTime DtTerminoPrevista { get; set; }

        public decimal CustoEstimado { get; set; }
        
        public int SituacaoProjetoId { get; set; }

        public List<ParteInteressadaProjeto> PartesInteressadasProjeto { get; set; }
    }
}
