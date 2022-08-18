using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class TipoDocumento
    {
        public decimal Idtipodocumento { get; set; }
        public string Desctipodoc { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<TipoDocumento> ReadAll()
        {
            return db.TIPO_DOCUMENTO.Select(t => new TipoDocumento()
            {
                Idtipodocumento = t.ID_TIPO_DOCUMENTO,
                Desctipodoc = t.DESCRIPCION_TIPO_DOC
            }).ToList();
        }
    }
}
