using System.ComponentModel.DataAnnotations;

namespace Sgiq.Web.Models
{
    public class RequisitoView
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public int ProjetoId { get; set; }

        [Required]
        public int TipoRequisitoId { get; set; }
        
    }

    public class RequisitoEditView: RequisitoView, EditableModel
    {
        public int Id { get; set; }
    }
}
