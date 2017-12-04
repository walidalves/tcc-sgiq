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

        }

        /* Tabelas Auxiliares */
        public virtual DbSet<Condicao> Condicao { get; set; }
        public virtual DbSet<Papel> Papel { get; set; }
        public virtual DbSet<SituacaoProjeto> SituacaoProjeto { get; set; }
        public virtual DbSet<TipoDado> TipoDado { get; set; }
        public virtual DbSet<TipoRequisito> TipoRequisito { get; set; }
        public virtual DbSet<Projeto> Projeto { get; set; }
        public virtual DbSet<ParteInteressada> ParteInteressada { get; set; }
        public virtual DbSet<ParteInteressadaProjeto> ParteInteressadaProjeto { get; set; }


    }
}
