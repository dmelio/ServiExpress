using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiExpressV3.datos;

namespace ServiExpressV3.negocio
{
    public class EstadoOrdenCompra
    {
        public decimal Idestado { get; set; }
        public string Descestado { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<EstadoOrdenCompra> ReadAll()
        {
            return db.ESTADO_ORDEN_COMPRA.Select(e => new EstadoOrdenCompra()
            {
                Idestado = e.ID_ESTADO_ORDEN,
                Descestado = e.DESCRIPCION_ESTADO
            }).ToList();
        }
    }
}
