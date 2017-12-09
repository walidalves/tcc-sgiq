using Microsoft.EntityFrameworkCore;
using Sgiq.Dados.Models;

namespace Sgiq.Dados
{
    public partial class SGIQContext : DbContext
    {
        /* Tabelas Auxiliares */
        public virtual DbSet<Condicao> Condicao { get; set; }
        public virtual DbSet<Papel> Papel { get; set; }
        public virtual DbSet<SituacaoProjeto> SituacaoProjeto { get; set; }
        public virtual DbSet<TipoDado> TipoDado { get; set; }
        public virtual DbSet<TipoRequisito> TipoRequisito { get; set; }

        //Subsistema Gerenciar projetos
        public virtual DbSet<Projeto> Projeto { get; set; }
        public virtual DbSet<ParteInteressada> ParteInteressada { get; set; }
        public virtual DbSet<ParteInteressadaProjeto> ParteInteressadaProjeto { get; set; }
        public virtual DbSet<Atividade> Atividade { get; set; }
        public virtual DbSet<Requisito> Requisito { get; set; }

        //subsistema GerenciarMetricas
        public virtual DbSet<Medida> Medida { get; set; }
        public virtual DbSet<Metrica> Metrica { get; set; }
        public virtual DbSet<Indicador> Indicador { get; set; }
        public virtual DbSet<Medicao> Medicao { get; set; }
    }
}
