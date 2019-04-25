using System;
using ExPagos.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CreateDTOs
{
    public partial class PagosdbContext : DbContext
    {
        public PagosdbContext()
        {
        }

        public PagosdbContext(DbContextOptions<PagosdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CLIENTE> Clientes { get; set; }
        public virtual DbSet<PAGO> Pagoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:pruebasca.database.windows.net,1433;Database=Pagosdb;User Id=scruz;Password=2019Pru3b@;");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<CLIENTE>(entity =>
            {
                entity.ToTable("CLIENTEs");

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PAGO>(entity =>
            {
                entity.ToTable("PAGOes");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pagoes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PAGOes_CLIENTEs");
            });
        }
    }
}
