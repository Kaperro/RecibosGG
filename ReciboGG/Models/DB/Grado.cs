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
    
    public partial class Grado
    {
        public int Id_Grado { get; set; }
        public Nullable<long> Id_Alumno { get; set; }
        public Nullable<long> Id_Maestra { get; set; }
        public string Nombre { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Maestra Maestra { get; set; }
    }
}
