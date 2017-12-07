using Sgiq.Dados;
using System;

namespace Sgiq.Negocio.Servicos
{
    public abstract class NegocioBase
    {
        public NegocioBase()
        {
            Db = new SGIQContext();
        }

        protected SGIQContext Db { get; set; }
    }
}
