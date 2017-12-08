using System;
using System.ComponentModel.DataAnnotations;

namespace Sgiq.Web.Models
{
    public class ParteInteressadaView
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
    }
    public class ParteInteressadaEdit : ParteInteressadaView, EditableModel
    {
        public int Id { get; set; }
    }
}
