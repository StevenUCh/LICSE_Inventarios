//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LICSE_Inventarios.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ENTRADA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENTRADA()
        {
            this.ENTRADA_SOLICITUD = new HashSet<ENTRADA_SOLICITUD>();
        }
    
        public int id_registro { get; set; }
        public Nullable<int> elemento { get; set; }
        public Nullable<int> cant { get; set; }
        public System.DateTime fecha { get; set; }
        public Nullable<int> usuario { get; set; }
    
        public virtual ELEMENTO ELEMENTO1 { get; set; }
        public virtual USUARIO USUARIO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENTRADA_SOLICITUD> ENTRADA_SOLICITUD { get; set; }
    }
}
