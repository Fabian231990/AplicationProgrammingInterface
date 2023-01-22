using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AccesoDatos.Models
{
    public partial class BDAppInterfaceContext : DbContext
    {
        public BDAppInterfaceContext()
        {
        }

        public BDAppInterfaceContext(DbContextOptions<BDAppInterfaceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Cuenta> Cuenta { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Parametro> Parametros { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_100_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Persona");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta);

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoCuenta)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cuenta_Cliente");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.IdMovimiento)
                    .HasName("PK_Movimiento");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SaldoInicial).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TipoMovimiento)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.IdCuenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Movimiento_Cuenta");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("Persona");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
