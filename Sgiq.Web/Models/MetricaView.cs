using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sgiq.Web.Models
{
    public class MetricaView
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public int FrequenciaAfericaoId { get; set; }

        [Required]
        public string Formula { get; set; }
    }
    public class MetricaEditView: MetricaView, EditableModel
    {
        public int Id { get; set; }
    }
}
