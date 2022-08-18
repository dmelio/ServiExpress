using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class Usuario
    {
        //Creacion de variables clase usuario, con sus restricciones
        [Required,MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres y el formato 12345678-9")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string RutUsuario { get; set; }
        [Required, MinLength(3,ErrorMessage=("El {0} debe tener un minimo de {1} caracteres")), MaxLength(100, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))] 
        public string NombreUsuario { get; set; }
        [Required,EmailAddress]public string Correo { get; set; }
        [Required, MinLength(5)] public string paswd { get; set; }
        [Required] public decimal IdRolUsuario { get; set; }
        [Required] public string DireccionUsuario { get; set; }
        [Required,Phone] public string TelefonoUsuario { get; set; }

        public RolUsuario RolUsuario { get; set; }
       
        //llamado a la base de datos asignandole el nombre "db"
        ServiExpressEntities db = new ServiExpressEntities();
        
        //Metodo que crea una lista con todos los registros dento de la tabla Usuario
        public List<Usuario> ReadAll()
        {
            return this.db.USUARIO.Select(u => new Usuario()
            {
                RutUsuario = u.RUT_USUARIO,
                NombreUsuario = u.NOM_AP_USUARIO,
                Correo = u.CORREO,
                paswd = u.PASWD,
                IdRolUsuario = u.ID_ROL_USUARIO,
                DireccionUsuario = u.DIRECCION_USUARIO,
                TelefonoUsuario = u.TELEFONO_USUARIO,
                RolUsuario = new RolUsuario()
                {
                    idrol = u.ID_ROL_USUARIO,
                    nombre_rol = u.ROL_USUARIO.NOMBRE_ROL
                }
            }).ToList();
        }

        //Metodo que llama al procedimiento almacenado que inserta datos en la tabla
        public bool Save()
        {
            try
            {
                db.SP_CREATE_USUARIO(this.RutUsuario, this.NombreUsuario, this.Correo, Encrypt.GetSHA256(this.paswd), this.IdRolUsuario,
                  this.DireccionUsuario, this.TelefonoUsuario);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Metodo que realiza la busqueda de un usuario segun su rut
        public Usuario Find(string rut)
        {
            return this.db.USUARIO.Select(u => new Usuario()
            {
                RutUsuario = u.RUT_USUARIO,
                NombreUsuario = u.NOM_AP_USUARIO,
                Correo = u.CORREO,
                paswd = u.PASWD,
                IdRolUsuario = (int)u.ID_ROL_USUARIO,
                DireccionUsuario = u.DIRECCION_USUARIO,
                TelefonoUsuario = u.TELEFONO_USUARIO,
                RolUsuario = new RolUsuario()
                {
                    idrol = (int)u.ID_ROL_USUARIO,
                    nombre_rol = u.ROL_USUARIO.NOMBRE_ROL
                }
            }).Where(u => u.RutUsuario == rut).FirstOrDefault();
        }
        //Metodo que llama al procedimiento para realizar un actualizacion de un registro en la base de datos
        public bool Update()
        {
            try
            {
                db.SP_UPDATE_USUARIO(this.RutUsuario, this.NombreUsuario, this.Correo,this.paswd, this.IdRolUsuario,
                  this.DireccionUsuario, this.TelefonoUsuario);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Metodo llama procedimiento que elimina un registo, en este caso elimina el registro que coincida con el id(rut usuario) que entra al metodo.
        public bool Delete(string id)
        {
            try
            {
                db.SP_DELETE_USER(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
