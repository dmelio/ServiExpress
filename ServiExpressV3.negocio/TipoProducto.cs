using ServiExpressV3.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiExpressV3.negocio
{
    public class TipoProducto
    {
        public decimal Idtipoprod { get; set; }
        public string Desctipoprod { get; set; }
        public decimal Idfamprod { get; set; }
        public FamiliaProducto FamiliaProducto { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();

        public List<TipoProducto> ReadAll()
        {
            return db.TIPO_PRODUCTO.Select(t => new TipoProducto()
            {
                Idtipoprod = t.ID_TIPO_PRODUCTO,
                Desctipoprod = t.DESCRIPCION_TIPO_PROD,
                Idfamprod = (decimal)t.ID_FAMILIA_PRODUCTO,
                FamiliaProducto = new FamiliaProducto()
                {
                    IdfamiliaProd = (decimal)t.ID_FAMILIA_PRODUCTO,
                    Descfamprod = t.FAMILIA_PRODUCTO.DESCRIPCION_FAMILIA_PROD
                }
            }).ToList();
        }
    }
}
