using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class FormaPago
    {
        public decimal Idformapago { get; set; }
        public string Nomforma { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<FormaPago> ReadAll()
        {
            return db.FORMA_PAGO.Select(f => new FormaPago()
            {
                Idformapago = f.ID_FORMA,
                Nomforma = f.NOMBRE_FORMA
            }).ToList();
        }
    }
}
