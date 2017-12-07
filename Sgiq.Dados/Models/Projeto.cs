using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public class Projeto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjetoId { get; set; }

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

        public decimal CustoEstimado { get; set; }

        public int SituacaoProjetoId { get; set; }

        public virtual List<ParteInteressadaProjeto> PartesInteressadasProjeto { get; set; }

        public virtual List<Atividade> Atividades { get; set; }

        public virtual List<Requisito> Requisitos { get; set; }

        public virtual List<IndicadorProjeto> IndicadoresProjeto { get; set; }

        public virtual List<Medicao> Medicoes { get; set; }

        public virtual AvaliacaoProjeto AvaliacaoProjeto { get; set; }

        public virtual SituacaoProjeto SituacaoProjeto{ get; set; }


    }
}
