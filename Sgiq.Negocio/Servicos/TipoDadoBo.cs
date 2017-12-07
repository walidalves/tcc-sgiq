using Sgiq.Dados;
using Sgiq.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sgiq.Negocio.Servicos
{
    public class TipoDadoBo: NegocioBase
    {
        public void Criar()
        {            
            if (!Db.TipoDado.Any())
            {
                Db.TipoDado.Add(new TipoDado { Nome = "Inteiro" });
                Db.TipoDado.Add(new TipoDado { Nome = "Decimal" });
                Db.SaveChanges();
            }
        }
    }
}
