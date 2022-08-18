using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class Servicio
    {
        public decimal Idservicio { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string Rutusuario { get; set; }
        [Required, MinLength(3, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres")), MaxLength(50, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string nomapusuario { get; set; }
        [Required, StringLength(6, ErrorMessage = ("El campo {0} debe tener un largo de {1} caracteres"))]
        public string patente { get; set; }
        [Required(ErrorMessage ="Ingrese un id de servicio valido")]
        public decimal idtiposerv { get; set; }
        [Required (ErrorMessage ="Ingrese un id de venta valido")]
        public decimal idprodventa { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string rutmecanico { get; set; }
        [Required, MinLength(3, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres")), MaxLength(50, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string nommecanico { get; set; }
        [Required, StringLength(17,ErrorMessage = "El campo {0} debe tener un largo de {1} caracteres")]
        public decimal codproducto { get; set; }
        public TipoServicio TipoServicio { get; set; }
        public Vehiculos Vehiculos { get; set; }
        public VentaProducto VentaProducto { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<Servicio> ReadAll()
        {
            return this.db.SERVICIO.Select(s => new Servicio()
            {
                Idservicio = s.ID_SERVICIO,
                Rutusuario = s.RUT_USUARIO,
                nomapusuario = s.NOM_AP_USUARIO,
                patente = s.PATENTE_VEHICULO,
                idtiposerv = s.ID_TIPO_SERVICIO,
                idprodventa =s.ID_PROD_VENTA,
                rutmecanico = s.RUT_MECANICO,
                nommecanico = s.NOMBRE_MECANICO,
                codproducto = (decimal)s.CODIGO_PRODUCTO,
                TipoServicio = new TipoServicio()
                {
                    Idtiposerv = s.ID_TIPO_SERVICIO,
                    Desctipo = s.TIPO_SERVICIO.DESCRIPCION_TIPO_SERV
                }

            }).ToList();
        }
        public bool Save()
        {
            try
            {
                db.SP_CREATE_SERVICIO(this.Rutusuario,this.nomapusuario,this.patente,this.idtiposerv,this.idprodventa,this.rutmecanico,this.nommecanico,this.codproducto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Servicio Find(int id)
        {
            return this.db.SERVICIO.Select(s => new Servicio()
            {
                Idservicio = s.ID_SERVICIO,
                Rutusuario = s.RUT_USUARIO,
                nomapusuario = s.NOM_AP_USUARIO,
                patente = s.PATENTE_VEHICULO,
                idtiposerv = s.ID_TIPO_SERVICIO,
                idprodventa = s.ID_PROD_VENTA,
                rutmecanico = s.RUT_MECANICO,
                nommecanico = s.NOMBRE_MECANICO,
                codproducto = (decimal)s.CODIGO_PRODUCTO,
                TipoServicio = new TipoServicio()
                {
                    Idtiposerv = s.ID_TIPO_SERVICIO,
                    Desctipo = s.TIPO_SERVICIO.DESCRIPCION_TIPO_SERV
                }
            }).Where(s => s.Idservicio == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_SERVICIO(this.Idservicio,this.Rutusuario, this.nomapusuario, this.patente, this.idtiposerv, this.idprodventa, this.rutmecanico, this.nommecanico, this.codproducto);
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
                db.SP_DELETE_SERVICIO(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
