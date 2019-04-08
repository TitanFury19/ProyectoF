namespace ProyectoF.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class finalDBCONTEXT : DbContext
    {
        public finalDBCONTEXT()
            : base("name=finalDBCONTEXT")
        {
        }

        public virtual DbSet<cargo> cargoes { get; set; }
        public virtual DbSet<Departamento> Departamentoes { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Licencia> Licencias { get; set; }
        public virtual DbSet<Nomina> Nominas { get; set; }
        public virtual DbSet<Permiso> Permisoes { get; set; }
        public virtual DbSet<Salida> Salidas { get; set; }
        public virtual DbSet<Vacacione> Vacaciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cargo>()
                .Property(e => e.Cargo1)
                .IsUnicode(false);

            modelBuilder.Entity<cargo>()
                .HasMany(e => e.Empleados)
                .WithOptional(e => e.cargo1)
                .HasForeignKey(e => e.Cargo);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Empleados)
                .WithOptional(e => e.Departamento1)
                .HasForeignKey(e => e.Departamento);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Estatus)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Licencias)
                .WithOptional(e => e.Empleado)
                .HasForeignKey(e => e.FK_Empleado);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Nominas)
                .WithOptional(e => e.Empleado)
                .HasForeignKey(e => e.FK_Empleado);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Permisoes)
                .WithOptional(e => e.Empleado)
                .HasForeignKey(e => e.FK_Empleado);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Salidas)
                .WithOptional(e => e.Empleado)
                .HasForeignKey(e => e.FK_Empleado);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Vacaciones)
                .WithOptional(e => e.Empleado)
                .HasForeignKey(e => e.FK_Empleado);

            modelBuilder.Entity<Licencia>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Nomina>()
                .Property(e => e.Monto_Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Nomina>()
                .Property(e => e.Dia)
                .IsUnicode(false);

            modelBuilder.Entity<Nomina>()
                .Property(e => e.Mes)
                .IsUnicode(false);

            modelBuilder.Entity<Nomina>()
                .Property(e => e.Año)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Salida>()
                .Property(e => e.Tipo_Salida)
                .IsUnicode(false);

            modelBuilder.Entity<Salida>()
                .Property(e => e.Motivo)
                .IsUnicode(false);

            modelBuilder.Entity<Salida>()
                .Property(e => e.Dia)
                .IsUnicode(false);

            modelBuilder.Entity<Salida>()
                .Property(e => e.Mes)
                .IsUnicode(false);

            modelBuilder.Entity<Salida>()
                .Property(e => e.Año)
                .IsUnicode(false);

            modelBuilder.Entity<Vacacione>()
                .Property(e => e.Comentario)
                .IsUnicode(false);
        }
    }
}
