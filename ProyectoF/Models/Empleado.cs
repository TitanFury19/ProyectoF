namespace ProyectoF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleados")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            Licencias = new HashSet<Licencia>();
            Nominas = new HashSet<Nomina>();
            Permisoes = new HashSet<Permiso>();
            Salidas = new HashSet<Salida>();
            Vacaciones = new HashSet<Vacacione>();
        }

        public int ID { get; set; }

        public int? Codigo_Empleado { get; set; }

        public int? Departamento { get; set; }

        [StringLength(15)]
        public string Nombre { get; set; }

        [StringLength(15)]
        public string Apellido { get; set; }

        public int? Cargo { get; set; }

        [Column(TypeName = "money")]
        public decimal? Salario { get; set; }

        public DateTime? Fecha_DE_Ingreso { get; set; }

        [StringLength(10)]
        public string Telefono { get; set; }

        [StringLength(10)]
        public string Estatus { get; set; }

        public virtual cargo cargo1 { get; set; }

        public virtual Departamento Departamento1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Licencia> Licencias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nomina> Nominas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permiso> Permisoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salida> Salidas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacacione> Vacaciones { get; set; }
    }
}
