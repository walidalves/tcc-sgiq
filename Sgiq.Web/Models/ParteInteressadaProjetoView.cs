using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sgiq.Web.Models
{
    public class ParteInteressadaProjetoView
    {
        [Required]
        public int ProjetoId { get; set; }

        [Required]
        public int ParteInteressadaId { get; set; }

        [Required]
        public int PapelId { get; set; }

    }

    public class ParteInteressadaProjetoEditView: ParteInteressadaProjetoView, EditableModel
    {
        public int Id { get; set; }
    }
}
