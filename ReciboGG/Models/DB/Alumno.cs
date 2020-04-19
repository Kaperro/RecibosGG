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
    
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            this.Gradoes = new HashSet<Grado>();
            this.Reciboes = new HashSet<Recibo>();
        }
    
        public long Id_Alumno { get; set; }
        public long Id_Tutor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<int> Edad { get; set; }
        public Nullable<bool> Solvente { get; set; }
    
        public virtual Tutor Tutor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Grado> Gradoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recibo> Reciboes { get; set; }
    }
}
