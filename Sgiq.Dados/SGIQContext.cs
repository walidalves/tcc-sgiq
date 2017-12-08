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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            this.ParteInteressadaProjetoModelCreating(modelBuilder);
            this.MedidaMetricaModelCreating(modelBuilder);
            this.IndicadorProjetoModelCreating(modelBuilder);
            this.AvaliacaoProjetoModelCreating(modelBuilder);
            this.AvaliacaoRequisitotoModelCreating(modelBuilder);
        }


        private void ParteInteressadaProjetoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParteInteressadaProjeto>()
                .HasKey(pi => new { pi.ProjetoId, pi.ParteInteressadaId });
            modelBuilder.Entity<ParteInteressadaProjeto>()
                .HasOne<Projeto>(p => p.Projeto)
                .WithMany(p => p.PartesInteressadasProjeto)
                .HasForeignKey(p => p.ProjetoId);

            modelBuilder.Entity<ParteInteressadaProjeto>()
                .HasOne<ParteInteressada>(p => p.ParteInteressada)
                .WithMany(p => p.PartesInteressadasProjeto)
                .HasForeignKey(p => p.ParteInteressadaId);

            modelBuilder.Entity<ParteInteressadaProjeto>()
                .HasOne<Papel>(p => p.Papel)
                .WithMany(p => p.PartesInteressadasProjeto)
                .HasForeignKey(p => p.PapelId);

        }

        private void MedidaMetricaModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedidaMetrica>()
                .HasKey(mm => new { mm.MedidaId, mm.MetricaId });

            modelBuilder.Entity<MedidaMetrica>()
                .HasOne<Medida>(mm => mm.Medida)
                .WithMany(m => m.MedidasMetrica)
                .HasForeignKey(mm => mm.MedidaId);

            modelBuilder.Entity<MedidaMetrica>()
                .HasOne<Metrica>(mm => mm.Metrica)
                .WithMany(m => m.MedidasMetrica)
                .HasForeignKey(mm => mm.MetricaId);
        }

        private void IndicadorProjetoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndicadorProjeto>()
                .HasKey(ip => new { ip.IndicadorId, ip.ProjetoId });

            modelBuilder.Entity<IndicadorProjeto>()
                .HasOne<Indicador>(ip => ip.Indicador)
                .WithMany(i => i.IndicadoresProjeto)
                .HasForeignKey(ip => ip.IndicadorId);

            modelBuilder.Entity<IndicadorProjeto>()
                .HasOne<Projeto>(ip => ip.Projeto)
                .WithMany(p => p.IndicadoresProjeto)
                .HasForeignKey(ip => ip.ProjetoId);
        }

        private void AvaliacaoProjetoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvaliacaoProjeto>()
                .HasOne(ap => ap.Projeto)
                .WithOne(p => p.AvaliacaoProjeto)
                .HasForeignKey<AvaliacaoProjeto>(ap => ap.ProjetoId);
        }

        private void AvaliacaoRequisitotoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvaliacaoRequisito>()
                .HasOne(ar => ar.Requisito)
                .WithOne(r => r.AvaliacaoRequisito)
                .HasForeignKey<AvaliacaoRequisito>(ar => ar.RequisitoId);
        }


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
