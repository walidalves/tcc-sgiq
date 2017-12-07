using System;
using System.Collections.Generic;
using System.Text;

namespace Sgiq.Negocio.ViewModel
{
    public class ProjetoViewModel
    {
        
    }

    public class ProjetoListarViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cliente { get; set; }
        public string GerenteProjeto { get; set; }
        public string Situacao { get; set; }
    }
}
