using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class OrdenDeCompra
    {
        public decimal Idorden { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres y el formato 12345678-9")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string Rutusuario { get; set; }
        [Required(ErrorMessage ="ingrese un id de producto valido")]
        public decimal Idproducto { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha valida")]
        [DataType(DataType.Date)]
        public DateTime Fechacreacion { get; set; }
        public decimal Idestado { get; set; }
        [Required, Range(1, 99999999, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public decimal Monto { get; set; }

        public Producto Producto { get; set; }
        public Usuario Usuario { get; set; }
        public EstadoOrdenCompra EstadoOrdenCompra { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<OrdenDeCompra> ReadAll()
        {
            return this.db.ORDEN_DE_COMPRA.Select(o => new OrdenDeCompra()
            {
                Idorden = o.ID_ORDEN,
                Rutusuario = o.RUT_USUARIO,
                Idproducto = o.ID_PRODUCTO,
                Fechacreacion = o.FECHA_DE_CREACION,
                Idestado = o.ID_ESTADO_ORDEN,
                Monto = o.MONTO,
                EstadoOrdenCompra = new EstadoOrdenCompra()
                {
                    Idestado = o.ID_ESTADO_ORDEN,
                    Descestado = o.ESTADO_ORDEN_COMPRA.DESCRIPCION_ESTADO
                },
                Producto = new Producto()
                {
                    Idproducto = o.ID_PRODUCTO,
                    Nombreprod = o.PRODUCTOS.NOMBRE_PRODUCTO
                }
            }).ToList();
        }
        public bool Save()
        {
            try
            {
                db.SP_CREATE_ODC(this.Rutusuario, this.Idproducto, this.Fechacreacion, this.Idestado, this.Monto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public OrdenDeCompra Find(int id)
        {
            return this.db.ORDEN_DE_COMPRA.Select(o => new OrdenDeCompra()
            {
                Idorden = o.ID_ORDEN,
                Rutusuario = o.RUT_USUARIO,
                Idproducto = o.ID_PRODUCTO,
                Fechacreacion = o.FECHA_DE_CREACION,
                Idestado = o.ID_ESTADO_ORDEN,
                Monto = o.MONTO,
                EstadoOrdenCompra = new EstadoOrdenCompra()
                {
                    Idestado = o.ID_ESTADO_ORDEN,
                    Descestado = o.ESTADO_ORDEN_COMPRA.DESCRIPCION_ESTADO
                },
                Producto = new Producto()
                {
                    Idproducto = o.ID_PRODUCTO,
                    Nombreprod = o.PRODUCTOS.NOMBRE_PRODUCTO
                }
            }).Where(o => o.Idorden == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_ODC(this.Idorden, this.Rutusuario, this.Idproducto, this.Fechacreacion, this.Idestado, this.Monto);
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
                db.SP_DELETE_ODC(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
