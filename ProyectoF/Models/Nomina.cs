namespace ProyectoF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nomina")]
    public partial class Nomina
    {
        public int ID { get; set; }

        [Column(TypeName = "money")]
        public decimal? Monto_Total { get; set; }

        public int? FK_Empleado { get; set; }

        [StringLength(2)]
        public string Dia { get; set; }

        [StringLength(12)]
        public string Mes { get; set; }

        [StringLength(4)]
        public string Año { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
