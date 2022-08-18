using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiExpressV3.datos;

namespace ServiExpressV3.negocio
{
    public class FamiliaProducto
    {
        public decimal IdfamiliaProd { get; set; }
        public string Descfamprod { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<FamiliaProducto> ReadAll()
        {
            return db.FAMILIA_PRODUCTO.Select(f => new FamiliaProducto()
            {
                IdfamiliaProd = f.ID_FAMILIA_PRODUCTO,
                Descfamprod = f.DESCRIPCION_FAMILIA_PROD
            }).ToList();
        }
    }
}
