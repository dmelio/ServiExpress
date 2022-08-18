using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiExpressV3.datos;

namespace ServiExpressV3.negocio
{
    public class DocumentoTributario
    {
        public decimal IdDocTibutario { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public Nullable<DateTime> FechaCreacion { get; set; }
        public decimal Idtipodoc { get; set; }
        [Required(ErrorMessage ="Ingrese un id de servicio valido")]
        public decimal Idservicio { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres y el formato 12345678-9")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string Rutusuariovend { get; set; }
        public decimal Idformapago { get; set; }
        [Required, MinLength(3, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres")), MaxLength(100, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string nomcliente { get; set; }
        [Required, MinLength(8, ErrorMessage = ("El {0} debe tener un minimo de {1} caracteres y el formato 12345678-9")), MaxLength(10, ErrorMessage = ("El {0} debe tener un maximo de {1} caracteres"))]
        public string rutcliente { get; set; }
        [Required, Range(1, 999999999999, ErrorMessage = "El {0} debe estar entre {1} y {2}")]
        public decimal totalpagar { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public FormaPago FormaPago { get; set; }

        ServiExpressEntities db = new ServiExpressEntities();
        public List<DocumentoTributario> ReadAll()
        {
            return this.db.DOCUMENTO_TRIBUTARIO.Select(d => new DocumentoTributario()
            {
                IdDocTibutario = d.ID_DOCUMENTO_TRIB,
                FechaCreacion = (DateTime)d.FECHA_DE_CREACION,
                Idtipodoc = d.ID_TIPO_DOC,
                Idservicio = d.ID_SERVICIO,
                Rutusuariovend = d.RUT_USUARIO_VEND,
                Idformapago = d.ID_FORMA_PAGO,
                nomcliente = d.NOMBRE_CLIENTE,
                rutcliente = d.RUT_CLIENTE,
                totalpagar =(decimal)d.TOTAL_PAGAR,
                TipoDocumento = new TipoDocumento()
                {
                    Idtipodocumento = d.ID_TIPO_DOC,
                    Desctipodoc = d.TIPO_DOCUMENTO.DESCRIPCION_TIPO_DOC
                },
                FormaPago = new FormaPago()
                {
                    Idformapago = d.ID_FORMA_PAGO,
                    Nomforma = d.FORMA_PAGO.NOMBRE_FORMA
                }
            }).ToList();
        }

        public List<DocumentoTributario> ReadAllporid(int id)
        {
            return this.db.DOCUMENTO_TRIBUTARIO.Select(d => new DocumentoTributario()
            {
                IdDocTibutario = d.ID_DOCUMENTO_TRIB,
                FechaCreacion = (DateTime)d.FECHA_DE_CREACION,
                Idtipodoc = d.ID_TIPO_DOC,
                Idservicio = d.ID_SERVICIO,
                Rutusuariovend = d.RUT_USUARIO_VEND,
                Idformapago = d.ID_FORMA_PAGO,
                nomcliente = d.NOMBRE_CLIENTE,
                rutcliente = d.RUT_CLIENTE,
                totalpagar = (decimal)d.TOTAL_PAGAR,
                TipoDocumento = new TipoDocumento()
                {
                    Idtipodocumento = d.ID_TIPO_DOC,
                    Desctipodoc = d.TIPO_DOCUMENTO.DESCRIPCION_TIPO_DOC
                },
                FormaPago = new FormaPago()
                {
                    Idformapago = d.ID_FORMA_PAGO,
                    Nomforma = d.FORMA_PAGO.NOMBRE_FORMA
                }
            }).Where(d => d.IdDocTibutario == id).ToList();
        }
        public DocumentoTributario Find(int id)
        {
            return this.db.DOCUMENTO_TRIBUTARIO.Select(d => new DocumentoTributario()
            {
                IdDocTibutario = d.ID_DOCUMENTO_TRIB,
                FechaCreacion = (DateTime)d.FECHA_DE_CREACION,
                Idtipodoc = d.ID_TIPO_DOC,
                Idservicio = d.ID_SERVICIO,
                Rutusuariovend = d.RUT_USUARIO_VEND,
                Idformapago = d.ID_FORMA_PAGO,
                nomcliente = d.NOMBRE_CLIENTE,
                rutcliente = d.RUT_CLIENTE,
                totalpagar = (decimal)d.TOTAL_PAGAR,
                TipoDocumento = new TipoDocumento()
                {
                    Idtipodocumento = d.ID_TIPO_DOC,
                    Desctipodoc = d.TIPO_DOCUMENTO.DESCRIPCION_TIPO_DOC
                },
                FormaPago = new FormaPago()
                {
                    Idformapago = d.ID_FORMA_PAGO,
                    Nomforma = d.FORMA_PAGO.NOMBRE_FORMA
                }
            }).Where(d => d.IdDocTibutario == id).FirstOrDefault();
        }
        public bool Save()
        {
            try
            {
                db.SP_CREATE_DOCTRIB(this.FechaCreacion, this.Idtipodoc, this.Idservicio, this.Rutusuariovend, this.Idformapago,this.nomcliente,this.rutcliente,this.totalpagar);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                db.SP_UPDATE_DOCTRIB(this.IdDocTibutario,this.FechaCreacion, this.Idtipodoc, this.Idservicio, this.Rutusuariovend, this.Idformapago, this.nomcliente, this.rutcliente,this.totalpagar);
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
                db.SP_DELETE_DOCTRIB(id);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
