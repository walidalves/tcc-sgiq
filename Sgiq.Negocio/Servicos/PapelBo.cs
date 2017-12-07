using Sgiq.Dados;
using Sgiq.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sgiq.Negocio.Servicos
{
    public class PapelBo: NegocioBase
    {
        public void Criar()
        {
            IQueryable papeis = Db.Papel;
            if (!Db.Papel.Any())
            {
                Db.Papel.Add(new Papel {Nome = "Gerente de Projetos" });
                Db.Papel.Add(new Papel { Nome = "Cliente" });
                Db.Papel.Add(new Papel { Nome = "Desenvolvedor" });
                Db.SaveChanges();
            }
        }
    }
}
