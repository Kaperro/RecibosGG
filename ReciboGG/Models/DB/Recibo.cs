//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReciboGG.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recibo
    {
        public long Id_Recibo { get; set; }
        public long Id_Alumno { get; set; }
        public long Id_Tutor { get; set; }
        public int Id_Pago_Detalle { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string Lugar { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Pago_Detalle Pago_Detalle { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
