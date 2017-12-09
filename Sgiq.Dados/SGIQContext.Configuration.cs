using Microsoft.EntityFrameworkCore;
using Sgiq.Dados.Models;

namespace Sgiq.Dados
{
    public partial class SGIQContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(@"server=localhost;port=3306;database=sgiq;uid=root;pwd=p3sq!!!sa");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this.ProjetoModelCreating(modelBuilder);
            this.ParteInteressadaProjetoModelCreating(modelBuilder);
            this.MedidaMetricaModelCreating(modelBuilder);
            this.IndicadorProjetoModelCreating(modelBuilder);
            this.AvaliacaoProjetoModelCreating(modelBuilder);
            this.AvaliacaoRequisitotoModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void ProjetoModelCreating(ModelBuilder modelBuilder)
        {
            // Add the shadow property to the model
            modelBuilder.Entity<SituacaoProjeto>()
                .Property<int>("SituacaoProjetoId");

            // Use the shadow property as a foreign key
            modelBuilder.Entity<Projeto>()
                .HasOne(p => p.SituacaoProjeto)
                .WithMany(b => b.Projetos)
                .HasForeignKey("SituacaoProjetoId");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void AvaliacaoProjetoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvaliacaoProjeto>()
                .HasOne(ap => ap.Projeto)
                .WithOne(p => p.AvaliacaoProjeto)
                .HasForeignKey<AvaliacaoProjeto>(ap => ap.ProjetoId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void AvaliacaoRequisitotoModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvaliacaoRequisito>()
                .HasOne(ar => ar.Requisito)
                .WithOne(r => r.AvaliacaoRequisito)
                .HasForeignKey<AvaliacaoRequisito>(ar => ar.RequisitoId);
        }
    }
}