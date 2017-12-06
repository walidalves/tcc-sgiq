using Sgiq.Dados;
using Sgiq.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sgiq.Negocio
{
    public class TipoRequisitoBo: NegocioBase
    {
        public void Criar()
        {
            
            if (!Db.TipoRequisito.Any())
            {
                Db.TipoRequisito.Add(new TipoRequisito {Nome = "Requisito Funcional" });
                Db.TipoRequisito.Add(new TipoRequisito { Nome = "Requisito Não Funcional" });
                Db.SaveChanges();
            }
        }
    }
}
