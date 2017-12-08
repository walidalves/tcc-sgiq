using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sgiq.Web.Models
{
    public class ProjetoView
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int GerenteProjetoId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public DateTime DtInicioPrevisto { get; set; }

        [Required]
        public DateTime DtTFimPrevisto { get; set; }

        [Required]
        public decimal CustoEstimado { get; set; }
    }
    public class ProjetoEditView : ProjetoView,EditableModel
    {
        public int Id { get; set; }
    }
}
