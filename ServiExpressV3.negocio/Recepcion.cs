using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiExpressV3.datos;

namespace ServiExpressV3.negocio
{
    public class Recepcion
    {
        public decimal idRecepcion { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres y el formato 12345678-9")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string rutUsuario { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime fechaRecepcion { get; set; }
        public string observaciones { get; set; }
        [Required(ErrorMessage ="Ingrese id de orden valido")]
        public decimal idOrdenCompra { get; set; }
        public Usuario Usuario { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<Recepcion> ReadAll()
        {
            return this.db.RECEPCION.Select(r => new Recepcion()
            {
                idRecepcion = r.ID_RECEPCION,
                rutUsuario = r.RUT_USUARIO,
                fechaRecepcion = (DateTime)r.FECHA_RECEPCION,
                observaciones = r.OBSERVACIONES,
                idOrdenCompra = r.ID_ORDEN_COMPRA

            }).ToList();     
        }

        public bool Save()
        {
            try
            {
                db.SP_CREATE_RECEPCION(this.rutUsuario, this.fechaRecepcion, this.observaciones, this.idOrdenCompra);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Recepcion Find(int id)
        {
            return this.db.RECEPCION.Select(r => new Recepcion()
            {
                idRecepcion = r.ID_RECEPCION,
                rutUsuario = r.RUT_USUARIO,
                fechaRecepcion = (DateTime)r.FECHA_RECEPCION,
                observaciones = r.OBSERVACIONES,
                idOrdenCompra = r.ID_ORDEN_COMPRA
            }).Where(r => r.idRecepcion == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_RECEPCION(this.idRecepcion, this.rutUsuario, this.fechaRecepcion, this.observaciones, this.idOrdenCompra);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.SP_DELETE_RECEPCION(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
