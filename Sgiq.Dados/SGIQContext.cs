using Microsoft.EntityFrameworkCore;
using Sgiq.Dados.Models;

namespace Sgiq.Dados
{
    public class SGIQContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(@"server=localhost;port=3306;database=sgiq;uid=root;pwd=p3sq!!!sa");
        }

        /* Tabelas Auxiliares */
        public virtual DbSet<Condicao> Condicao { get; set; }
        public virtual DbSet<Papel> Papel { get; set; }
        public virtual DbSet<SituacaoProjeto> SituacaoProjeto { get; set; }
        public virtual DbSet<TipoDado> TipoDado { get; set; }
        public virtual DbSet<TipoRequisito> TipoRequisito { get; set; }
        

    }
}
