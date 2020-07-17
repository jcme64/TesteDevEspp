using Microsoft.EntityFrameworkCore;


namespace ExameApi.Models
{
	public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Conta> Conta { get; set; }
        public virtual DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.ToTable("tb_clientes");

                entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.NomeCliente)
                    .IsRequired()
                    .HasColumnName("nm_cliente")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CpfCnpj)
                    .HasColumnName("Cpf_Cnpj")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.TpCliente)
                    .HasColumnName("tp_cliente")
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.EMAil)
                    .HasColumnName("eMail")
                    .HasMaxLength(1)
                    .IsUnicode(false);
                
            });

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.ToTable("tb_conta");

                entity.HasKey(e => e.IdConta).HasName("PRIMARY");

                entity.Property(e => e.IdConta).HasColumnName("id_conta");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.NumeroConta)
                    .IsRequired()
                    .HasColumnName("nm_conta")
                    .HasMaxLength(8)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Lancamento>(entity =>
            {
                entity.ToTable("tb_lancamentos");

                entity.HasKey(e => e.IdLancamento).HasName("PRIMARY");

                entity.Property(e => e.IdLancamento).HasColumnName("id_lancamento");

                entity.Property(e => e.IdConta).HasColumnName("id_conta");

                entity.Property(e => e.DtLancamento)
                   .HasColumnName("dt_lancamento")
                   .HasColumnType("datetime");

                entity.Property(e => e.ValorLancamento).HasColumnName("vl_lancamento");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
          
    }
}
