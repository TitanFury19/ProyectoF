namespace ProyectoF.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Licencia
    {
        public int ID { get; set; }

        public int? FK_Empleado { get; set; }

        [StringLength(50)]
        public string Comentario { get; set; }

        public DateTime? Fecha_Entrada { get; set; }

        public DateTime? Fecha_Salida { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
