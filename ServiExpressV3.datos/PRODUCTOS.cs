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
    
    public partial class PRODUCTOS
    {
        public PRODUCTOS()
        {
            this.ORDEN_DE_COMPRA = new HashSet<ORDEN_DE_COMPRA>();
            this.VENTA_PRODUCTO = new HashSet<VENTA_PRODUCTO>();
        }
    
        public decimal ID_PRODUCTO { get; set; }
        public Nullable<decimal> CODIGO_PRODUCTO { get; set; }
        public decimal ID_PROVEEDOR { get; set; }
        public decimal ID_TIPO_PRODUCTO { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public string MARCA_PROD { get; set; }
        public string DESCRIPCION_PRODUCTO { get; set; }
        public Nullable<System.DateTime> FECHA_VENCIMIENTO { get; set; }
        public int PRECIO_VENTA { get; set; }
        public int PRECIO_COMPRA { get; set; }
        public int STOCK { get; set; }
    
        public virtual ICollection<ORDEN_DE_COMPRA> ORDEN_DE_COMPRA { get; set; }
        public virtual TIPO_PRODUCTO TIPO_PRODUCTO { get; set; }
        public virtual PROVEEDOR PROVEEDOR { get; set; }
        public virtual ICollection<VENTA_PRODUCTO> VENTA_PRODUCTO { get; set; }
    }
}