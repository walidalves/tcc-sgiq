using Sgiq.Dados;
using Sgiq.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sgiq.Negocio
{
    public class CondicaoBo: NegocioBase
    {
        public void Criar()
        {
            
            if (!Db.Condicao.Any())
            {
                Db.Condicao.Add(new Condicao {Nome = "Maior que" });
                Db.Condicao.Add(new Condicao { Nome = "Maior ou Igual a" });
                Db.Condicao.Add(new Condicao { Nome = "Igual a" });
                Db.Condicao.Add(new Condicao { Nome = "Menor ou Igual a" });
                Db.Condicao.Add(new Condicao { Nome = "Menor que" });
                Db.SaveChanges();
            }
        }
    }
}
