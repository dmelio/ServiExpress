//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiExpressV3.datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class OPERACIONES
    {
        public OPERACIONES()
        {
            this.ROL_OPERACION = new HashSet<ROL_OPERACION>();
        }
    
        public decimal ID { get; set; }
        public string NOMBRE_OP { get; set; }
    
        public virtual ICollection<ROL_OPERACION> ROL_OPERACION { get; set; }
    }
}