using Sgiq.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sgiq.Negocio.Servicos
{
    public class FrequenciaAfericaoBo: NegocioBase
    {
        public void Criar()
        {

            if (!Db.FrequenciaAfericao.Any())
            {
                Db.FrequenciaAfericao.Add(new FrequenciaAfericao { Nome = "Semanal" });
                Db.FrequenciaAfericao.Add(new FrequenciaAfericao { Nome = "Mensal" });
                Db.FrequenciaAfericao.Add(new FrequenciaAfericao { Nome = "Semestral" });
                Db.FrequenciaAfericao.Add(new FrequenciaAfericao { Nome = "Anual" });
                Db.SaveChanges();
            }
        }
    }
}
