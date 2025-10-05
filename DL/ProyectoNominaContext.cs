using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ProyectoNominaContext : DbContext
{
    public ProyectoNominaContext()
    {
    }

    public ProyectoNominaContext(DbContextOptions<ProyectoNominaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deduccione> Deducciones { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleNomina> DetalleNominas { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<HistorialPermiso> HistorialPermisos { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Prestacione> Prestaciones { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<StatusPermiso> StatusPermisos { get; set; }

    public virtual DbSet<TipoDeduccion> TipoDeduccions { get; set; }

    public virtual DbSet<TipoPrestacion> TipoPrestacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Login> LoginDTO { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ProyectoNomina;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<Deduccione>(entity =>
        {
            entity.HasKey(e => e.IdDeduccion).HasName("PK__Deduccio__5EDD827B6829AA73");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Deducciones)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deduccion__IdEmp__693CA210");

            entity.HasOne(d => d.IdTipoDeduccionNavigation).WithMany(p => p.Deducciones)
                .HasForeignKey(d => d.IdTipoDeduccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Deduccion__IdTip__6A30C649");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DE2E46BAF");

            entity.ToTable("Departamento");

            entity.Property(e => e.IdDepartamento).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<DetalleNomina>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleN__E43646A5C1BAA719");

            entity.ToTable("DetalleNomina");

            entity.Property(e => e.Concepto).HasMaxLength(100);
            entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.IdNominaNavigation).WithMany(p => p.DetalleNominas)
                .HasForeignKey(d => d.IdNomina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleNo__IdNom__6FE99F9F");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E731B5EF0");

            entity.ToTable("Empleado");

            entity.Property(e => e.ApellidoMaterno).HasMaxLength(100);
            entity.Property(e => e.ApellidoPaterno).HasMaxLength(100);
            entity.Property(e => e.Curp)
                .HasMaxLength(18)
                .HasColumnName("CURP");
            entity.Property(e => e.NoFaltas).HasDefaultValue(0);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Nss)
                .HasMaxLength(15)
                .HasColumnName("NSS");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .HasColumnName("RFC");
            entity.Property(e => e.SalarioBase).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__IdDepa__4D94879B");
        });

        modelBuilder.Entity<HistorialPermiso>(entity =>
        {
            entity.HasKey(e => e.IdHistorialPermiso).HasName("PK__Historia__0000E4BFFDB22803");

            entity.ToTable("HistorialPermiso");

            entity.Property(e => e.Observaciones).HasMaxLength(255);

            entity.HasOne(d => d.IdEmpleadoAccionNavigation).WithMany(p => p.HistorialPermisos)
                .HasForeignKey(d => d.IdEmpleadoAccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__IdEmp__5EBF139D");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.HistorialPermisos)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__IdPer__5CD6CB2B");

            entity.HasOne(d => d.IdStatusPermisoNavigation).WithMany(p => p.HistorialPermisos)
                .HasForeignKey(d => d.IdStatusPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__IdSta__5DCAEF64");
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.IdNomina).HasName("PK__Nomina__02F9D722F3143450");

            entity.ToTable("Nomina");

            entity.Property(e => e.SalarioBruto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SalarioNeto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalDeducciones).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Nomina__IdEmplea__6D0D32F4");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso).HasName("PK__Permiso__0D626EC8A0CA7EFB");

            entity.ToTable("Permiso");

            entity.Property(e => e.Motivo).HasMaxLength(255);

            entity.HasOne(d => d.IdAutorizadorNavigation).WithMany(p => p.PermisoIdAutorizadorNavigations)
                .HasForeignKey(d => d.IdAutorizador)
                .HasConstraintName("FK__Permiso__IdAutor__59FA5E80");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.PermisoIdEmpleadoNavigations)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permiso__IdEmple__5812160E");

            entity.HasOne(d => d.IdStatusPermisoNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdStatusPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permiso__IdStatu__59063A47");
        });

        modelBuilder.Entity<Prestacione>(entity =>
        {
            entity.HasKey(e => e.IdPrestacion).HasName("PK__Prestaci__63EE28349F4B1424");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Prestaciones)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestacio__IdEmp__6383C8BA");

            entity.HasOne(d => d.IdTipoPrestacionNavigation).WithMany(p => p.Prestaciones)
                .HasForeignKey(d => d.IdTipoPrestacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prestacio__IdTip__6477ECF3");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C4D4AEFBF");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(100);
        });

        modelBuilder.Entity<StatusPermiso>(entity =>
        {
            entity.HasKey(e => e.IdStatusPermiso).HasName("PK__StatusPe__D8526C07A1229923");

            entity.ToTable("StatusPermiso");

            entity.Property(e => e.IdStatusPermiso).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoDeduccion>(entity =>
        {
            entity.HasKey(e => e.IdTipoDeduccion).HasName("PK__TipoDedu__71FD8744D4A8025A");

            entity.ToTable("TipoDeduccion");

            entity.Property(e => e.IdTipoDeduccion).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Porcentaje).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<TipoPrestacion>(entity =>
        {
            entity.HasKey(e => e.IdTipoPrestacion).HasName("PK__TipoPres__26EE75DBA5129132");

            entity.ToTable("TipoPrestacion");

            entity.Property(e => e.IdTipoPrestacion).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97D9C0F2F1");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105349ED35790").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Status).HasDefaultValue(true);

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdEmple__5165187F");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdRol__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
