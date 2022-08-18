using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class Producto
    {
        public decimal Idproducto { get; set; }
        public decimal Codproducto { get; set; }
        [Required] public decimal Idproveedor { get; set; }
        [Required] public decimal Idtipoprod { get; set; }
        [Required,MinLength(3,ErrorMessage ="El {0} debe tener un minimo de {1} caracteres"),MaxLength(100)] public string Nombreprod { get; set; }
        [Required, MinLength(3, ErrorMessage = "El {0} debe tener un minimo de {1} caracteres")] public string Marcaprod { get; set; }
        public string Descprod { get; set; }
        public Nullable<DateTime> FechaVencimiento { get; set; }
        [Required,Range(1,99999999, ErrorMessage ="El {0} debe estar entre {1} y {2}")] public decimal Precioventa { get; set; }
        [Required,Range(1, 99999999, ErrorMessage = "El {0} debe estar entre {1} y {2}")] public decimal Preciocompra { get; set; }
        [Required,Range(1,999999999,ErrorMessage = "El {0} debe estar entre {1} y {2}")] public decimal stock { get; set; }

        public Proveedor Proveedor { get; set; }
        public TipoProducto TipoProducto { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<Producto> ReadAll()
        {
            return this.db.PRODUCTOS.Select(p => new Producto()
            {
                Idproducto = p.ID_PRODUCTO,
                Codproducto = (decimal)p.CODIGO_PRODUCTO,
                Idproveedor = p.ID_PROVEEDOR,
                Idtipoprod = p.ID_TIPO_PRODUCTO,
                Nombreprod = p.NOMBRE_PRODUCTO,
                Marcaprod = p.MARCA_PROD,
                Descprod = p.DESCRIPCION_PRODUCTO,
                FechaVencimiento = (DateTime)p.FECHA_VENCIMIENTO,
                Precioventa = p.PRECIO_VENTA,
                Preciocompra = p.PRECIO_COMPRA,
                stock = p.STOCK,
                Proveedor = new Proveedor()
                {
                    Idproveedor = p.ID_PROVEEDOR,
                    Razonsocial = p.PROVEEDOR.RAZON_SOCIAL
                },
                TipoProducto = new TipoProducto()
                {
                    Idtipoprod = p.ID_TIPO_PRODUCTO,
                    Idfamprod = (decimal)p.TIPO_PRODUCTO.ID_FAMILIA_PRODUCTO
                }
            }).ToList();
        }
        public bool Save()
        {
            try
            {
                db.SP_CREATE_PRODUCTO(null, this.Idproveedor, this.Idtipoprod, this.Nombreprod, this.Marcaprod,
                  this.Descprod, this.FechaVencimiento, this.Precioventa, this.Preciocompra, this.stock);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Producto Find(int id)
        {
            return this.db.PRODUCTOS.Select(p => new Producto()
            {
                Idproducto = p.ID_PRODUCTO,
                Codproducto = (decimal)p.CODIGO_PRODUCTO,
                Idproveedor = p.ID_PROVEEDOR,
                Idtipoprod = p.ID_TIPO_PRODUCTO,
                Nombreprod = p.NOMBRE_PRODUCTO,
                Marcaprod = p.MARCA_PROD,
                Descprod = p.DESCRIPCION_PRODUCTO,
                FechaVencimiento = (DateTime)p.FECHA_VENCIMIENTO,
                Precioventa = p.PRECIO_VENTA,
                Preciocompra = p.PRECIO_COMPRA,
                stock = p.STOCK,
                Proveedor = new Proveedor()
                {
                    Idproveedor = p.ID_PROVEEDOR,
                    Razonsocial = p.PROVEEDOR.RAZON_SOCIAL
                },
                TipoProducto = new TipoProducto()
                {
                    Idtipoprod = p.ID_TIPO_PRODUCTO,
                    Idfamprod = (decimal)p.TIPO_PRODUCTO.ID_FAMILIA_PRODUCTO
                }
            }).Where(p => p.Idproducto == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_PRODUCTO(this.Idproducto, this.Codproducto, this.Idproveedor, this.Idtipoprod, this.Nombreprod, this.Marcaprod,
                  this.Descprod, this.FechaVencimiento, this.Precioventa, this.Preciocompra, this.stock);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.SP_DELETE_PRODUCTO(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
