using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JsanchezGn3Context : DbContext
{
    public JsanchezGn3Context()
    {
    }

    public JsanchezGn3Context(DbContextOptions<JsanchezGn3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Sueldo> Sueldos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.; Database= JSanchezGN3; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Iddepartamento).HasName("PK__DEPARTAM__B529B33787184C46");

            entity.ToTable("DEPARTAMENTO");

            entity.Property(e => e.Iddepartamento).HasColumnName("IDDEPARTAMENTO");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Idempleado).HasName("PK__EMPLEADO__E014C316A59B5700");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.Idempleado).HasColumnName("IDEMPLEADO");
            entity.Property(e => e.Fechaingreso).HasColumnName("FECHAINGRESO");
            entity.Property(e => e.Fechanacimiento).HasColumnName("FECHANACIMIENTO");
            entity.Property(e => e.Iddepartamento).HasColumnName("IDDEPARTAMENTO");
            entity.Property(e => e.Idsueldo).HasColumnName("IDSUELDO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IddepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Iddepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartamentoEmpleado");

            entity.HasOne(d => d.IdsueldoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.Idsueldo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SueldoEmpleado");
        });

        modelBuilder.Entity<Sueldo>(entity =>
        {
            entity.HasKey(e => e.Idsueldo).HasName("PK__SUELDO__7200AA5D999C99B8");

            entity.ToTable("SUELDO");

            entity.Property(e => e.Idsueldo).HasColumnName("IDSUELDO");
            entity.Property(e => e.Formapago)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("FORMAPAGO");
            entity.Property(e => e.Sueldo1)
                .HasColumnType("decimal(20, 2)")
                .HasColumnName("SUELDO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
