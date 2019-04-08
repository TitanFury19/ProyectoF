namespace ProyectoF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Salida")]
    public partial class Salida
    {
        public int ID { get; set; }

        public int? FK_Empleado { get; set; }

        [StringLength(30)]
        public string Tipo_Salida { get; set; }

        [StringLength(30)]
        public string Motivo { get; set; }

        [StringLength(2)]
        public string Dia { get; set; }

        [StringLength(12)]
        public string Mes { get; set; }

        [StringLength(4)]
        public string Año { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
