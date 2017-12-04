using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sgiq.Dados.Models
{
    public class ParteInteressadaProjeto
    {
        [Key, Column(Order = 0)]
        public int ProjetoId { get; set; }

        [Key, Column(Order = 1)]
        public int ParteInteressadaId { get; set; }

        public int PapelId { get; set; }

        public Projeto Projeto { get; set; }

        public ParteInteressada ParteInteressada { get; set; }

        [ForeignKey("PapelId")]
        public Papel Papel { get; set; }
    }
}
