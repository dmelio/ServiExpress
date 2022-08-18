using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class RolUsuario
    {
        public decimal idrol { get; set; }
        public string nombre_rol { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<RolUsuario> ReadAll()
        {
            return db.ROL_USUARIO.Select(r => new RolUsuario()
            {
                idrol = r.ID_ROL,
                nombre_rol = r.NOMBRE_ROL
            }).ToList();
        }

    }
}

