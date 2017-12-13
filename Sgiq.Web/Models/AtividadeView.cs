using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sgiq.Web.Models
{
    public class AtividadeView
    {
        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int ProjetoId { get; set; }

        public DateTime DtInicio { get; set; }

        public DateTime DtFim { get; set; }
    }

    public class AtividadeEditView :AtividadeView, EditableModel
    {
        public int Id { get; set; }
    }
}
