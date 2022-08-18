using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class Proveedor
    {
        public decimal Idproveedor { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))] 
        public string Rutempresa { get; set; }
        [Required,MinLength(1,ErrorMessage =("El campo {0} debe tener minimo {1} caracteres"))]
        public string Razonsocial { get; set; }
        public string Direccion { get; set; }
        public decimal Idrubro { get; set; }
        [Required,Phone(ErrorMessage ="ingrese un numero de telefono valido")]public string Telefonocontact { get; set; }
        [Required,EmailAddress(ErrorMessage ="Ingrese un correo valido")]public string Correocontact { get; set; }

        public Rubro Rubro { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<Proveedor> ReadAll()
        {
            return this.db.PROVEEDOR.Select(p => new Proveedor()
            {
                Idproveedor = p.ID_PROVEEDOR,
                Rutempresa = p.RUT_EMPRESA,
                Razonsocial = p.RAZON_SOCIAL,
                Direccion = p.DIRECCION,
                Idrubro = p.ID_RUBRO,
                Rubro = new Rubro()
                {
                    Idrubro = p.ID_RUBRO,
                    Descripcionrubro = p.RUBRO.DESCRIPCION_RUBRO
                },
                Telefonocontact = p.TELEFONO_CONTACTO,
                Correocontact = p.CORREO_CONTACTO
            }).ToList();
        }
        public bool Save()
        {
            try
            {
                db.SP_CREATE_PROVEEDOR(this.Rutempresa, this.Razonsocial, this.Direccion, this.Idrubro, this.Telefonocontact, this.Correocontact);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Proveedor Find(int id)
        {
            return this.db.PROVEEDOR.Select(p => new Proveedor()
            {
                Idproveedor = p.ID_PROVEEDOR,
                Rutempresa = p.RUT_EMPRESA,
                Razonsocial = p.RAZON_SOCIAL,
                Direccion = p.DIRECCION,
                Idrubro = p.ID_RUBRO,
                Rubro = new Rubro()
                {
                    Idrubro = p.ID_RUBRO,
                    Descripcionrubro = p.RUBRO.DESCRIPCION_RUBRO
                },
                Telefonocontact = p.TELEFONO_CONTACTO,
                Correocontact = p.CORREO_CONTACTO  
            }).Where(p => p.Idproveedor == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_PROVEEDOR(this.Idproveedor, this.Rutempresa, this.Razonsocial, this.Direccion, this.Idrubro, this.Telefonocontact, this.Correocontact);
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
                db.SP_DELETE_PROVEEDOR(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
