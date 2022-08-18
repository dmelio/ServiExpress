using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class Reserva
    {
        public decimal Idreserva { get; set; }
        [Required (ErrorMessage ="Ingrese una fecha valida")]
        [DataType(DataType.Date)]
        public DateTime Fechareserva { get; set; }
        [Required(ErrorMessage ="Ingrese un servicio valido")] 
        public decimal Idtiposervicio { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres y el siguiente formato 12345678-9")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string Rutusuario { get; set; }
        [Required, MinLength(3, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres")), MaxLength(100, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string Nombrecliente { get; set; }
        [Required, EmailAddress(ErrorMessage ="ingrese un correo valido")]
        public string Correousuario { get; set; }
        [Required, StringLength(6, ErrorMessage = ("El campo {0} debe tener un largo de {1} caracteres"))]
        public string patente { get; set; }

        public TipoServicio TipoServicio { get; set; }
        public Usuario Usuario { get; set; }
        public Vehiculos Vehiculos { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<Reserva> ReadAll()
        {
            return this.db.RESERVAS.Select(r => new Reserva()
            {
                Idreserva = r.ID_RESERVA,
                Fechareserva = r.FECHA_RESERVA,
                Idtiposervicio =(decimal) r.ID_TIPO_SERVICIO,
                Rutusuario = r.RUT_USUARIO,
                Nombrecliente = r.NOM_AP_CLIENTE,
                Correousuario = r.CORREO_USUARIO,
                patente = r.PATENTE,
                TipoServicio = new TipoServicio()
                {
                    Idtiposerv = (decimal)r.ID_TIPO_SERVICIO,
                    Desctipo = r.TIPO_SERVICIO.DESCRIPCION_TIPO_SERV
                },
                Usuario = new Usuario()
                {
                    RutUsuario = r.RUT_USUARIO,
                    NombreUsuario = r.USUARIO.NOM_AP_USUARIO,
                },
                Vehiculos = new Vehiculos()
                {
                    Patente = r.PATENTE,
                    Marca = r.VEHICULOS.MARCA,
                    Modelo = r.VEHICULOS.MODELO
                }
            }).ToList();
        }
        public bool Save()
        {
            try
            {
                db.SP_CREATE_RESERVAS(this.Fechareserva, this.Rutusuario, this.Nombrecliente,this.Correousuario, this.patente,this.Idtiposervicio);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Reserva Find(int id)
        {
            return this.db.RESERVAS.Select(r => new Reserva()
            {
                Idreserva = r.ID_RESERVA,
                Fechareserva = r.FECHA_RESERVA,
                Idtiposervicio =(decimal) r.ID_TIPO_SERVICIO,
                Rutusuario = r.RUT_USUARIO,
                Nombrecliente = r.NOM_AP_CLIENTE,
                Correousuario = r.CORREO_USUARIO,
                patente = r.PATENTE,
                TipoServicio = new TipoServicio()
                {
                    Idtiposerv =(decimal) r.ID_TIPO_SERVICIO,
                    Desctipo = r.TIPO_SERVICIO.DESCRIPCION_TIPO_SERV
                },
                Usuario = new Usuario()
                {
                    RutUsuario = r.RUT_USUARIO,
                    NombreUsuario = r.NOM_AP_CLIENTE
                },
                Vehiculos = new Vehiculos()
                {
                    Patente = r.PATENTE,
                    Marca = r.VEHICULOS.MARCA,
                    Modelo = r.VEHICULOS.MODELO
                }
            }).Where(r => r.Idreserva == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_RESERVAS(this.Idreserva,this.Fechareserva, this.Rutusuario, this.Nombrecliente,this.Correousuario, this.patente,this.Idtiposervicio);
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
                db.SP_DELETE_RESERVAS(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
