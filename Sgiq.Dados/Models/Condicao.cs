﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sgiq.Dados.Models
{
    public partial class Condicao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CondicaoId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
    }
}
