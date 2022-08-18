using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class Vehiculos
    {
        [Required,StringLength(6,ErrorMessage =("El campo {0} debe tener un largo de {1} caracteres"))]
        public string Patente { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))] 
        public string RutUsuario { get; set; }
        [Required,MinLength(3)]public string Marca { get; set; }
        [Required]public string Modelo { get; set; }
        public decimal Anio { get; set; }

        public Usuario Usuario { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();
        public List<Vehiculos> ReadAll()
        {
            return this.db.VEHICULOS.Select(p => new Vehiculos()
            {
                Patente = p.PATENTE,
                RutUsuario = p.RUT_USUARIO,
                Marca = p.MARCA,
                Modelo = p.MODELO,
                Anio = (decimal)p.ANIO
            }).ToList();
        }
        public bool Save()
        {
            try
            {
                db.SP_CREATE_VEHICULO(this.Patente, this.RutUsuario, this.Marca, this.Modelo, this.Anio);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Vehiculos Find(string id)
        {
            return this.db.VEHICULOS.Select(p => new Vehiculos()
            {
                Patente = p.PATENTE,
                RutUsuario =p.RUT_USUARIO,
                Marca = p.MARCA,
                Modelo = p.MODELO,
                Anio = (decimal)p.ANIO
            }).Where(p => p.Patente == id).FirstOrDefault();
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_VEHICULO(this.Patente, this.RutUsuario, this.Marca, this.Modelo, (decimal)this.Anio);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                db.SP_DELETE_VEHICULO(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
