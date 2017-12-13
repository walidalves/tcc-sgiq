using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Sgiq.Web.Models
{
    public class MedidaView
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public int TipoDadoId { get; set; }
        
        public Nullable<decimal> VlrMinimo { get; set; }

        public Nullable<decimal> VlrMaximo { get; set; }
    }
    public class MedidaEditView : MedidaView, EditableModel
    {
        public int Id { get; set; }
    }
}
