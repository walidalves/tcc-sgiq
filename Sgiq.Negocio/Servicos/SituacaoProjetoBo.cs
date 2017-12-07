using System.Linq;
using Sgiq.Dados.Models;

namespace Sgiq.Negocio.Servicos
{

    public class SituacaoProjetoBo : NegocioBase
    {
        public void Criar()
        {
            
            if (!Db.SituacaoProjeto.Any())
            {
                Db.SituacaoProjeto.Add(new SituacaoProjeto { Nome = "Iniciado" });
                Db.SituacaoProjeto.Add(new SituacaoProjeto { Nome = "Encerrado" });
                Db.SaveChanges();
            }

        }
    }
}
