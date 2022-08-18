using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class Rubro
    {
        public decimal Idrubro { get; set; }
        public string Descripcionrubro { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();
        public List<Rubro> ReadAll()
        {
            return db.RUBRO.Select(r => new Rubro()
            {
                Idrubro = r.ID_RUBRO,
                Descripcionrubro = r.DESCRIPCION_RUBRO
            }).ToList();
        }
    }
}
