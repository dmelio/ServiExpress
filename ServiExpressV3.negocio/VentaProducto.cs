using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class VentaProducto
    {
        public decimal idProdVenta { get; set; }
        public decimal idProducto { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Codproducto { get; set; }

        public Producto Producto { get; set; }
        ServiExpressEntities db = new ServiExpressEntities();
        public List<VentaProducto> ReadAll()
        {
            return this.db.VENTA_PRODUCTO.Select(v => new VentaProducto()
            {
                idProdVenta = v.ID_PRODUCTO_VENTA,
                idProducto = v.ID_PRODUCTO,
                Cantidad = (decimal)v.CANTIDAD,
                Codproducto = (decimal)v.CODIGO_PRODUCTO,
                Producto = new Producto()
                {
                    Idproducto = (decimal)v.CODIGO_PRODUCTO,
                    Nombreprod = v.PRODUCTOS.NOMBRE_PRODUCTO

                }
            }).ToList();
        }
        public bool Save()
        {
            try
            {
                db.SP_CREATE_VPRODUCTO(this.idProducto, this.Cantidad, this.Codproducto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public VentaProducto Find(int id)
        {
            return this.db.VENTA_PRODUCTO.Select(v => new VentaProducto()
            {
                idProdVenta = v.ID_PRODUCTO_VENTA,
                idProducto = v.ID_PRODUCTO,
                Cantidad = (decimal)v.CANTIDAD,
                Codproducto = (decimal)v.CODIGO_PRODUCTO,
                Producto = new Producto()
                {
                    Idproducto = (decimal)v.CODIGO_PRODUCTO,
                    Nombreprod = v.PRODUCTOS.NOMBRE_PRODUCTO

                }
            }).Where(v => v.idProdVenta == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_VPRODUCTO(this.idProdVenta, this.idProducto, this.Cantidad, this.Codproducto);
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
                db.SP_DELETE_VPRODUCTO(this.idProdVenta);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
