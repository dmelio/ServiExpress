using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class TipoServicio
    {
        public decimal Idtiposerv { get; set; }
        public string Desctipo { get; set; }
        public decimal precio { get; set; }

        Usuario Usuario { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<TipoServicio> ReadAll()
        {
            return db.TIPO_SERVICIO.Select(t => new TipoServicio()
            {
                Idtiposerv = t.ID_TIPO_SERVICIO,
                Desctipo = t.DESCRIPCION_TIPO_SERV,
                precio = t.PRECIO,
            }).ToList();
        }
    }
}

