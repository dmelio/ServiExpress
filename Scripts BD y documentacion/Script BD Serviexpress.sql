-----Creacion de sequencias para rellenar campos "ID" de las tablas en las que era necesario----- 
--las sequencias parten desde 100 ya que hay requerimientos que nos piden tener un minimo de 3 caracteres en los id--
--
-- DOCTRIB_SEQ
--
 CREATE SEQUENCE "DOCTRIB_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- FAMILIA_PROD_SEQ
--
 CREATE SEQUENCE "FAMILIA_PROD_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- OPERACIONES_SEQ
--
 CREATE SEQUENCE "OPERACIONES_SEQ" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- ORDENCOMPRA_SEQ
--
 CREATE SEQUENCE "ORDENCOMPRA_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- PRODUCTO_SEQ
--
 CREATE SEQUENCE "PRODUCTO_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- PROVEEDOR_SEQ
--
 CREATE SEQUENCE "PROVEEDOR_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- RECEPCION_SEQ
--
 CREATE SEQUENCE "RECEPCION_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- RESERVA_SEQ
--
 CREATE SEQUENCE "RESERVA_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- ROLOP_SEQ
--
 CREATE SEQUENCE "ROLOP_SEQ" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- RUBRO_SEQ
--
 CREATE SEQUENCE "RUBRO_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- SERVICIO_SEQ
--
 CREATE SEQUENCE "SERVICIO_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- TIPO_PROD_SEQ
--
 CREATE SEQUENCE "TIPO_PROD_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- TIPOSERV_SEQ
--
 CREATE SEQUENCE "TIPOSERV_SEQ" MINVALUE 1 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
--
-- VPROD_SEQ
--
 CREATE SEQUENCE "VPROD_SEQ" MINVALUE 100 MAXVALUE 9999999999999999999999999999 INCREMENT BY 1 NOCACHE NOORDER NOCYCLE;
 
 ----Creacion de tablas segun ultimo Modelo entidad relacion------
--
-- DOCUMENTO_TRIBUTARIO
--
  CREATE TABLE "DOCUMENTO_TRIBUTARIO" 
   (	"ID_DOCUMENTO_TRIB" NUMBER,
	"FECHA_DE_CREACION" DATE,
	"ID_TIPO_DOC" NUMBER NOT NULL ENABLE,
	"ID_SERVICIO" NUMBER NOT NULL ENABLE,
	"RUT_USUARIO_VEND" VARCHAR2(10) NOT NULL ENABLE,
	"ID_FORMA_PAGO" NUMBER NOT NULL ENABLE,
	"NOMBRE_CLIENTE" VARCHAR2(200) NOT NULL ENABLE,
	"RUT_CLIENTE" VARCHAR2(10) NOT NULL ENABLE,
	"TOTAL_PAGAR" NUMBER NOT NULL ENABLE,
	PRIMARY KEY ("ID_DOCUMENTO_TRIB") ENABLE
   );
--
-- ESTADO_ORDEN_COMPRA
--
  CREATE TABLE "ESTADO_ORDEN_COMPRA" 
   (	"ID_ESTADO_ORDEN" NUMBER,
	"DESCRIPCION_ESTADO" VARCHAR2(200) NOT NULL ENABLE,
	PRIMARY KEY ("ID_ESTADO_ORDEN") ENABLE
   );
--
-- FAMILIA_PRODUCTO
--
  CREATE TABLE "FAMILIA_PRODUCTO" 
   (	"ID_FAMILIA_PRODUCTO" NUMBER,
	"DESCRIPCION_FAMILIA_PROD" VARCHAR2(100) NOT NULL ENABLE,
	PRIMARY KEY ("ID_FAMILIA_PRODUCTO") ENABLE
   );
--
-- FORMA_PAGO
--
  CREATE TABLE "FORMA_PAGO" 
   (	"ID_FORMA" NUMBER,
	"NOMBRE_FORMA" VARCHAR2(100),
	PRIMARY KEY ("ID_FORMA") ENABLE
   );
--
-- OPERACIONES
--
  CREATE TABLE "OPERACIONES" 
   (	"ID" NUMBER,
	"NOMBRE_OP" VARCHAR2(50),
	PRIMARY KEY ("ID") ENABLE
   );
--
-- ORDEN_DE_COMPRA
--
  CREATE TABLE "ORDEN_DE_COMPRA" 
   (	"ID_ORDEN" NUMBER,
	"RUT_USUARIO" VARCHAR2(10) NOT NULL ENABLE,
	"ID_PRODUCTO" NUMBER NOT NULL ENABLE,
	"FECHA_DE_CREACION" DATE DEFAULT sysdate NOT NULL ENABLE,
	"ID_ESTADO_ORDEN" NUMBER NOT NULL ENABLE,
	"MONTO" NUMBER NOT NULL ENABLE,
	PRIMARY KEY ("ID_ORDEN") ENABLE
   );
--
-- PRODUCTOS
--
  CREATE TABLE "PRODUCTOS" 
   (	"ID_PRODUCTO" NUMBER,
	"CODIGO_PRODUCTO" NUMBER(22,0),
	"ID_PROVEEDOR" NUMBER NOT NULL ENABLE,
	"ID_TIPO_PRODUCTO" NUMBER NOT NULL ENABLE,
	"NOMBRE_PRODUCTO" VARCHAR2(200) NOT NULL ENABLE,
	"MARCA_PROD" VARCHAR2(100) NOT NULL ENABLE,
	"DESCRIPCION_PRODUCTO" VARCHAR2(200),
	"FECHA_VENCIMIENTO" DATE,
	"PRECIO_VENTA" NUMBER(10,0) NOT NULL ENABLE,
	"PRECIO_COMPRA" NUMBER(10,0) NOT NULL ENABLE,
	"STOCK" NUMBER(10,0) NOT NULL ENABLE,
	PRIMARY KEY ("ID_PRODUCTO") ENABLE
   );
--
-- PROVEEDOR
--
  CREATE TABLE "PROVEEDOR" 
   (	"ID_PROVEEDOR" NUMBER,
	"RUT_EMPRESA" VARCHAR2(10) NOT NULL ENABLE,
	"RAZON_SOCIAL" VARCHAR2(200) NOT NULL ENABLE,
	"DIRECCION" VARCHAR2(200),
	"ID_RUBRO" NUMBER NOT NULL ENABLE,
	"TELEFONO_CONTACTO" VARCHAR2(12) NOT NULL ENABLE,
	"CORREO_CONTACTO" VARCHAR2(200) NOT NULL ENABLE,
	PRIMARY KEY ("ID_PROVEEDOR") ENABLE
   );
--
-- RECEPCION
--
  CREATE TABLE "RECEPCION" 
   (	"ID_RECEPCION" NUMBER,
	"RUT_USUARIO" VARCHAR2(10) NOT NULL ENABLE,
	"FECHA_RECEPCION" DATE,
	"OBSERVACIONES" VARCHAR2(250),
	"ID_ORDEN_COMPRA" NUMBER NOT NULL ENABLE,
	PRIMARY KEY ("ID_RECEPCION") ENABLE
   );
--
  CREATE TABLE "RESERVAS" 
   (	"ID_RESERVA" NUMBER,
	"FECHA_RESERVA" DATE NOT NULL ENABLE,
	"ID_TIPO_SERVICIO" NUMBER NOT NULL ENABLE,
	"RUT_USUARIO" VARCHAR2(10) NOT NULL ENABLE,
	"NOM_AP_CLIENTE" VARCHAR2(200) NOT NULL ENABLE,
	"CORREO_USUARIO" VARCHAR2(200) NOT NULL ENABLE,
	"PATENTE" VARCHAR2(6) NOT NULL ENABLE,
	PRIMARY KEY ("ID_RESERVA") ENABLE
   );
--
-- ROL_OPERACION
--
  CREATE TABLE "ROL_OPERACION" 
   (	"ID" NUMBER,
	"ID_ROL" NUMBER,
	"ID_OP" NUMBER,
	PRIMARY KEY ("ID") ENABLE
   );
--
-- ROL_USUARIO
--
  CREATE TABLE "ROL_USUARIO" 
   (	"ID_ROL" NUMBER,
	"NOMBRE_ROL" VARCHAR2(100),
	PRIMARY KEY ("ID_ROL") ENABLE
   );
--
-- RUBRO
--
  CREATE TABLE "RUBRO" 
   (	"ID_RUBRO" NUMBER,
	"DESCRIPCION_RUBRO" VARCHAR2(200) NOT NULL ENABLE,
	CONSTRAINT "ID_RUBRO_PK" PRIMARY KEY ("ID_RUBRO") ENABLE
   );
--
-- SERVICIO
--
  CREATE TABLE "SERVICIO" 
   (	"ID_SERVICIO" NUMBER,
	"RUT_USUARIO" VARCHAR2(10) NOT NULL ENABLE,
	"NOM_AP_USUARIO" VARCHAR2(200) NOT NULL ENABLE,
	"PATENTE_VEHICULO" VARCHAR2(6) NOT NULL ENABLE,
	"ID_TIPO_SERVICIO" NUMBER NOT NULL ENABLE,
	"ID_PROD_VENTA" NUMBER NOT NULL ENABLE,
	"RUT_MECANICO" VARCHAR2(10) NOT NULL ENABLE,
	"NOMBRE_MECANICO" VARCHAR2(200) NOT NULL ENABLE,
	"CODIGO_PRODUCTO" NUMBER(20,0),
	PRIMARY KEY ("ID_SERVICIO") ENABLE
   );
--
-- TIPO_DOCUMENTO
--
  CREATE TABLE "TIPO_DOCUMENTO" 
   (	"ID_TIPO_DOCUMENTO" NUMBER,
	"DESCRIPCION_TIPO_DOC" VARCHAR2(200) NOT NULL ENABLE,
	PRIMARY KEY ("ID_TIPO_DOCUMENTO") ENABLE
   );
--
-- TIPO_PRODUCTO
--
  CREATE TABLE "TIPO_PRODUCTO" 
   (	"ID_TIPO_PRODUCTO" NUMBER,
	"DESCRIPCION_TIPO_PROD" VARCHAR2(100) NOT NULL ENABLE,
	"ID_FAMILIA_PRODUCTO" NUMBER,
	PRIMARY KEY ("ID_TIPO_PRODUCTO") ENABLE
   );
--
-- TIPO_SERVICIO
--
  CREATE TABLE "TIPO_SERVICIO" 
   (	"ID_TIPO_SERVICIO" NUMBER,
	"DESCRIPCION_TIPO_SERV" VARCHAR2(200) NOT NULL ENABLE,
	"PRECIO" NUMBER NOT NULL ENABLE,
	PRIMARY KEY ("ID_TIPO_SERVICIO") ENABLE
   );
--
-- USUARIO
--
  CREATE TABLE "USUARIO" 
   (	"RUT_USUARIO" VARCHAR2(10),
	"NOM_AP_USUARIO" VARCHAR2(200) NOT NULL ENABLE,
	"CORREO" VARCHAR2(200) NOT NULL ENABLE,
	"PASWD" VARCHAR2(25) NOT NULL ENABLE,
	"ID_ROL_USUARIO" NUMBER NOT NULL ENABLE,
	"DIRECCION_USUARIO" VARCHAR2(200),
	"TELEFONO_USUARIO" VARCHAR2(12) NOT NULL ENABLE,
	PRIMARY KEY ("RUT_USUARIO") ENABLE
   );
--
-- VEHICULOS
--
  CREATE TABLE "VEHICULOS" 
   (	"PATENTE" VARCHAR2(6),
	"RUT_USUARIO" VARCHAR2(10) NOT NULL ENABLE,
	"MARCA" VARCHAR2(100) NOT NULL ENABLE,
	"MODELO" VARCHAR2(50) NOT NULL ENABLE,
	"ANIO" NUMBER(4,0),
	PRIMARY KEY ("PATENTE") ENABLE
   );
--
-- VENTA_PRODUCTO
--
  CREATE TABLE "VENTA_PRODUCTO" 
   (	"ID_PRODUCTO_VENTA" NUMBER,
	"ID_PRODUCTO" NUMBER NOT NULL ENABLE,
	"CANTIDAD" NUMBER,
	"CODIGO_PRODUCTO" NUMBER(20,0),
	PRIMARY KEY ("ID_PRODUCTO_VENTA") ENABLE
   );
   
-------------------Creacion de trigger para generar codigo de producto como se solicita el cliente------------------
-------Al momento de guardar un producto viene por defecto un valor NULL en el codigo de producto,por lo que el trigger se encarga de crear el codigo tomando los 3 primeros digitos del id proveedor
------- los primeros 3 id familia + la fecha de vencimiento +  primeros 3 digitos de tipo_producto para reemplazar el valor null.
------
--
-- COD_PRODUCTO
--
  CREATE OR REPLACE TRIGGER "COD_PRODUCTO"
  BEFORE INSERT OR UPDATE ON "PRODUCTOS"FOR EACH ROW
  DECLARE
	ID_FAMILIA NUMBER ;
BEGIN
	SELECT sp.ID_FAMILIA_PRODUCTO INTO ID_FAMILIA FROM TIPO_PRODUCTO sp 
	WHERE ID_TIPO_PRODUCTO = :NEW.ID_TIPO_PRODUCTO;
	:NEW.CODIGO_PRODUCTO := TO_NUMBER(LPAD(:NEW.ID_PROVEEDOR, 3, '0') 
		|| LPAD((ID_FAMILIA), 3, '0') 
		|| CASE 
			WHEN :NEW.FECHA_VENCIMIENTO IS NULL
				THEN '00000000'
			ELSE TO_CHAR(:NEW.FECHA_VENCIMIENTO, 'YYYYMMDD')
			END 
		|| LPAD(:NEW.ID_TIPO_PRODUCTO, 3, '0'));
END;
/

---------------------------creacion llaves foranea------------------
--
-- SYS_C008963
--
ALTER TABLE "DOCUMENTO_TRIBUTARIO" ADD  FOREIGN KEY ("ID_SERVICIO") REFERENCES "SERVICIO"("ID_SERVICIO") ENABLE;

--
-- SYS_C008964
--
ALTER TABLE "DOCUMENTO_TRIBUTARIO" ADD  FOREIGN KEY ("ID_FORMA_PAGO") REFERENCES "FORMA_PAGO"("ID_FORMA") ENABLE;

--
-- SYS_C008965
--
ALTER TABLE "DOCUMENTO_TRIBUTARIO" ADD  FOREIGN KEY ("RUT_USUARIO_VEND") REFERENCES "USUARIO"("RUT_USUARIO") ENABLE;

--
-- SYS_C008966
--
ALTER TABLE "DOCUMENTO_TRIBUTARIO" ADD  FOREIGN KEY ("ID_TIPO_DOC") REFERENCES "TIPO_DOCUMENTO"("ID_TIPO_DOCUMENTO") ENABLE;

--
-- SYS_C008939
--
ALTER TABLE "ORDEN_DE_COMPRA" ADD  FOREIGN KEY ("ID_ESTADO_ORDEN") REFERENCES "ESTADO_ORDEN_COMPRA"("ID_ESTADO_ORDEN") ENABLE;

--
-- SYS_C008940
--
ALTER TABLE "ORDEN_DE_COMPRA" ADD  FOREIGN KEY ("RUT_USUARIO") REFERENCES "USUARIO"("RUT_USUARIO") ENABLE;

--
-- SYS_C008941
--
ALTER TABLE "ORDEN_DE_COMPRA" ADD  FOREIGN KEY ("ID_PRODUCTO") REFERENCES "PRODUCTOS"("ID_PRODUCTO") ENABLE;

--
-- SYS_C008942
--
ALTER TABLE "PRODUCTOS" ADD  FOREIGN KEY ("ID_TIPO_PRODUCTO") REFERENCES "TIPO_PRODUCTO"("ID_TIPO_PRODUCTO") ENABLE;

--
-- SYS_C008943
--
ALTER TABLE "PRODUCTOS" ADD  FOREIGN KEY ("ID_PROVEEDOR") REFERENCES "PROVEEDOR"("ID_PROVEEDOR") ENABLE;

--
-- SYS_C008944
--
ALTER TABLE "PROVEEDOR" ADD  FOREIGN KEY ("ID_RUBRO") REFERENCES "RUBRO"("ID_RUBRO") ENABLE;

--
-- SYS_C008938
--
ALTER TABLE "RECEPCION" ADD  FOREIGN KEY ("ID_ORDEN_COMPRA") REFERENCES "ORDEN_DE_COMPRA"("ID_ORDEN") ENABLE;

--
-- SYS_C008945
--
ALTER TABLE "RESERVAS" ADD  FOREIGN KEY ("RUT_USUARIO") REFERENCES "USUARIO"("RUT_USUARIO") ENABLE;

--
-- SYS_C008946
--
ALTER TABLE "RESERVAS" ADD  FOREIGN KEY ("ID_TIPO_SERVICIO") REFERENCES "TIPO_SERVICIO"("ID_TIPO_SERVICIO") ENABLE;

--
-- SYS_C008947
--
ALTER TABLE "RESERVAS" ADD  FOREIGN KEY ("PATENTE") REFERENCES "VEHICULOS"("PATENTE") ENABLE;

--
-- SYS_C008973
--
ALTER TABLE "ROL_OPERACION" ADD  FOREIGN KEY ("ID_ROL") REFERENCES "ROL_USUARIO"("ID_ROL") ENABLE;

--
-- SYS_C008974
--
ALTER TABLE "ROL_OPERACION" ADD  FOREIGN KEY ("ID_OP") REFERENCES "OPERACIONES"("ID") ENABLE;

--
-- SYS_C008948
--
ALTER TABLE "SERVICIO" ADD  FOREIGN KEY ("PATENTE_VEHICULO") REFERENCES "VEHICULOS"("PATENTE") ENABLE;

--
-- SYS_C008949
--
ALTER TABLE "SERVICIO" ADD  FOREIGN KEY ("ID_TIPO_SERVICIO") REFERENCES "TIPO_SERVICIO"("ID_TIPO_SERVICIO") ENABLE;

--
-- SYS_C008950
--
ALTER TABLE "SERVICIO" ADD  FOREIGN KEY ("ID_PROD_VENTA") REFERENCES "VENTA_PRODUCTO"("ID_PRODUCTO_VENTA") ENABLE;

--
-- SYS_C008951
--
ALTER TABLE "TIPO_PRODUCTO" ADD  FOREIGN KEY ("ID_FAMILIA_PRODUCTO") REFERENCES "FAMILIA_PRODUCTO"("ID_FAMILIA_PRODUCTO") ENABLE;

--
-- SYS_C008952
--
ALTER TABLE "USUARIO" ADD  FOREIGN KEY ("ID_ROL_USUARIO") REFERENCES "ROL_USUARIO"("ID_ROL") ENABLE;

--
-- SYS_C008953
--
ALTER TABLE "VEHICULOS" ADD  FOREIGN KEY ("RUT_USUARIO") REFERENCES "USUARIO"("RUT_USUARIO") ENABLE;

--
-- SYS_C008954
--
ALTER TABLE "VENTA_PRODUCTO" ADD  FOREIGN KEY ("ID_PRODUCTO") REFERENCES "PRODUCTOS"("ID_PRODUCTO") ENABLE;

--
-- SP_BUSCAR_POR_RUT
--
CREATE OR REPLACE PROCEDURE "SP_BUSCAR_POR_RUT" (v_rutusuario VARCHAR2) as
begin
SELECT ALL AS 
FROM usuario 
WHERE rut_usuario = v_rutusuario;
ORDER BY v_rutusuario ASC
end;
/

------------------PS CREACION--------------------
--
-- SP_CREATE_DOCTRIB
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_DOCTRIB" (v_fechacrea date,v_idtipodoc number,v_idservicio number,v_rutusuario varchar2,v_idformapago number,v_nomcliente varchar2,v_rutcliente varchar2,v_totalpagar number)as
begin
insert into documento_tributario values(doctrib_seq.nextval,v_fechacrea,v_idtipodoc,v_idservicio,v_rutusuario ,v_idformapago,v_nomcliente,v_rutcliente,v_totalpagar);
end;
/
--
-- SP_CREATE_ODC
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_ODC" (v_rutusuario VARCHAR2,v_idproducto NUMBER,v_fechacreacion date,v_idestadoorden number,v_monto number)as
begin
insert into ORDEN_DE_COMPRA values(ordencompra_seq.nextval, v_rutusuario,v_idproducto,v_fechacreacion,v_idestadoorden,v_monto);
end;
/
--
-- SP_CREATE_PRODUCTO
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_PRODUCTO" (v_codprod number,v_idproveedor NUMBER,v_idtipoprod number,v_nombreprod varchar2,v_marcaprod varchar2,v_descprod varchar2,
v_fechavenc date,v_precioventa number,v_preciocompra number,v_stock number)as
begin
insert into PRODUCTOS values(producto_seq.nextval, v_codprod ,v_idproveedor ,v_idtipoprod ,v_nombreprod ,v_marcaprod ,v_descprod ,
v_fechavenc ,v_precioventa ,v_preciocompra ,v_stock );
end;
/
--
-- SP_CREATE_PROVEEDOR
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_PROVEEDOR" (v_rutEmpresa VARCHAR2,v_razonSocial varchar2,v_direccion varchar2,v_idRubro number,v_telefonoContacto varchar2,v_correoContacto varchar2) as
begin
insert into PROVEEDOR values(proveedor_seq.nextval,v_rutEmpresa,v_razonSocial,v_direccion,v_idRubro ,v_telefonoContacto ,v_correoContacto);
end;
/
--
-- SP_CREATE_RECEPCION
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_RECEPCION" (v_rutusuario varchar2,v_fecharecep date,v_observaciones varchar2,v_idordencompra number)as
begin
insert into RECEPCION values(recepcion_seq.nextval,v_rutusuario,v_fecharecep,v_observaciones,v_idordencompra);
end;
/
--
-- SP_CREATE_RESERVAS
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_RESERVAS" (v_fechareserva date,v_idservicio NUMBER,v_rutusuario varchar2,v_nombreclie varchar2,v_correousu varchar2,v_patente varchar2)as
begin
insert into RESERVAS values(reserva_seq.nextval, v_fechareserva,v_idservicio ,v_rutusuario ,v_nombreclie ,v_correousu ,v_patente );
end;
/
--
-- SP_CREATE_RUBRO
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_RUBRO" (v_descRubro VARCHAR2) as
begin
insert into rubro values(rubro_seq.nextval,v_descRubro);
end;
/
--
-- SP_CREATE_SERVICIO
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_SERVICIO" (v_rutusuario varchar2,v_nomapusuario varchar2,v_patente varchar2,v_idtiposerv number,v_idprodvent number,v_rutmecanico varchar2,v_nommec varchar2,v_codproducto number)as
begin
insert into SERVICIO values(servicio_seq.nextval,v_rutusuario,v_nomapusuario,v_patente,v_idtiposerv,v_idprodvent,v_rutmecanico,v_nommec,v_codproducto);
end;
/
--
-- SP_CREATE_USUARIO
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_USUARIO" (v_rutusuario varchar2,v_nomapusuario varchar2,v_correo varchar2,V_paswd varchar2,
                                               v_idrol number,v_direccionusuario varchar2,v_telefonousuario varchar2) as
begin
insert into usuario values(v_rutusuario,v_nomapusuario,v_correo,v_paswd,v_idrol,v_direccionusuario,v_telefonousuario);
end;
/
--
-- SP_CREATE_VEHICULO
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_VEHICULO" (v_patente varchar2,v_rutusuario VARCHAR2,v_marca varchar2,v_modelo varchar2,v_anio number) as
begin
insert into vehiculos values(v_patente,v_rutusuario,v_marca,v_modelo,v_anio);
end;
/
--
-- SP_CREATE_VPRODUCTO
--
CREATE OR REPLACE PROCEDURE "SP_CREATE_VPRODUCTO" (v_idproducto number,v_cantidad number,v_codproducto number)as
begin
insert into VENTA_PRODUCTO values(vprod_seq.nextval,v_idproducto,v_cantidad,v_codproducto);
end;
/
-----------------SP ELIMINAR-------------
--
-- SP_DELETE_DOCTRIB
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_DOCTRIB" (v_iddoctrib NUMBER) as
begin
delete from documento_tributario where id_documento_trib = v_iddoctrib;
commit;
end;
/
--
-- SP_DELETE_ODC
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_ODC" (v_idorden NUMBER) as
begin
delete from ORDEN_DE_COMPRA where id_orden = v_idorden;
commit;
end;
/
--
-- SP_DELETE_PRODUCTO
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_PRODUCTO" (v_idproducto NUMBER) as
begin
delete from PRODUCTOS where id_producto = v_idproducto;
commit;
end;
/
--
-- SP_DELETE_PROVEEDOR
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_PROVEEDOR" (v_idProveedor NUMBER) as
begin
delete from PROVEEDOR where id_proveedor = v_idProveedor;
commit;
end;
/
--
-- SP_DELETE_RECEPCION
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_RECEPCION" (v_idrecepcion NUMBER) as
begin
delete from RECEPCION where id_recepcion = v_idrecepcion;
commit;
end;
/
--
-- SP_DELETE_RESERVAS
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_RESERVAS" (v_idreservas NUMBER) as
begin
delete from RESERVAS where id_reserva = v_idreservas;
commit;
end;
/
--
-- SP_DELETE_RUBRO
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_RUBRO" (v_idrubro number) as
begin
delete from rubro where id_rubro = V_idrubro;
commit;
end;
/
--
-- SP_DELETE_SERVICIO
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_SERVICIO" (v_idservicio NUMBER) as
begin
delete from SERVICIO where id_servicio = v_idservicio;
commit;
end;
/
--
-- SP_DELETE_USER
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_USER" (v_rutusuario VARCHAR2) as
begin
delete from usuario where RUT_USUARIO = v_rutusuario;
commit;
end;
/
--
-- SP_DELETE_VEHICULO
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_VEHICULO" (v_patente varchar2) as
begin
delete from vehiculos where patente = v_patente;
commit;
end;
/
--
-- SP_DELETE_VPRODUCTO
--
CREATE OR REPLACE PROCEDURE "SP_DELETE_VPRODUCTO" (v_idprodventa NUMBER) as
begin
delete from VENTA_PRODUCTO where id_producto_venta = v_idprodventa;
commit;
end;
/
---------------------SP MODIFICAR-----------------
-- SP_UPDATE_DOCTRIB
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_DOCTRIB" (v_iddoctrib number,v_fechacrea date,v_idtipodoc number,v_idservicio number,v_rutusuario varchar2,v_idformapago number,v_nomcliente varchar2,v_rutcliente varchar2,v_totalpagar number)as
begin
    UPDATE documento_tributario
    SET fecha_de_creacion = v_fechacrea,
        id_tipo_doc = v_idtipodoc,
        id_servicio = v_idservicio,
        rut_usuario_vend = v_rutusuario,
        id_forma_pago = v_idformapago,
        nombre_cliente = v_nomcliente,
        rut_cliente = v_rutcliente,
        total_pagar = v_totalpagar
    where id_documento_trib = v_iddoctrib;
    commit;
end;
/
--
-- SP_UPDATE_ODC
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_ODC" (v_idorden NUMBER, v_rutusuario VARCHAR2,v_idproducto NUMBER,v_fechacreacion date,v_idestadoorden number,v_monto number) as
begin
    UPDATE ORDEN_DE_COMPRA
    SET rut_usuario = v_rutusuario,
        id_producto =v_idproducto,
        fecha_de_creacion = v_fechacreacion,
        id_estado_orden = v_idestadoorden,
        monto = v_monto
    where   id_orden = v_idorden;
    commit;
end;
/
--
-- SP_UPDATE_PRODUCTO
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_PRODUCTO" (v_idproducto NUMBER, v_codusuario number,v_idproveedor NUMBER,v_idtipoprod number,v_nombreprod varchar2,v_marcaprod varchar2,v_descprod varchar2,
v_fechavenc date,v_precioventa number,v_preciocompra number,v_stock number) as
begin
    UPDATE PRODUCTOS
    SET codigo_producto = v_codusuario,
        id_proveedor =v_idproveedor,
        id_tipo_producto = v_idtipoprod,
        nombre_producto = v_nombreprod,
        marca_prod = v_marcaprod,
        descripcion_producto = v_descprod,
        fecha_vencimiento = v_fechavenc,
        precio_venta = v_precioventa,
        precio_compra = v_preciocompra,
        stock = v_stock
    where  id_producto = v_idproducto;
    commit;
end;
/
--
-- SP_UPDATE_PROVEEDOR
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_PROVEEDOR" (v_idProveedor NUMBER,v_rutEmpresa VARCHAR2,v_razonSocial varchar2,v_direccion varchar2,v_idRubro number,v_telefonoContacto varchar2,v_correoContacto varchar2) as
begin
    UPDATE PROVEEDOR
    SET rut_empresa = v_rutEmpresa,
        razon_social =v_razonSocial,
        direccion = v_direccion,
        id_rubro = v_idRubro,
        telefono_contacto = v_telefonoContacto,
        correo_contacto = v_correoContacto
    where id_proveedor= v_idProveedor;
    commit;
end;
/
--
-- SP_UPDATE_RECEPCION
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_RECEPCION" (v_idrecepcion number,v_rutusuario varchar2,v_fecharecep date,v_observaciones varchar2,v_idordencompra number) as
begin
    UPDATE RECEPCION
    SET rut_usuario = v_rutusuario,
        fecha_recepcion =v_fecharecep,
        observaciones = v_observaciones,
        id_orden_compra = v_idordencompra
    where id_recepcion= v_idrecepcion;
    commit;
end;
/
--
-- SP_UPDATE_RESERVAS
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_RESERVAS" (v_idreservas NUMBER, v_fechareserva date,v_idservicio NUMBER,v_rutusuario varchar2,v_nombreclie varchar2,v_correousu varchar2,v_patente varchar2) as
begin
    UPDATE RESERVAS
    SET fecha_reserva = v_fechareserva,
        id_servicio = v_idservicio,
        rut_usuario = v_rutusuario,
        nom_ap_cliente = v_nombreclie,
        correo_usuario = v_correousu,
        patente = v_patente
    where   id_reserva = v_idreservas;
    commit;
end;
/
--
-- SP_UPDATE_RUBRO
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_RUBRO" (v_idrubro number,v_descRubro VARCHAR2) as
begin
    UPDATE rubro
    SET descripcion_rubro = v_descRubro
    where id_rubro= v_idrubro;
    commit;
end;
/
--
-- SP_UPDATE_SERVICIO
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_SERVICIO" (v_idservicio NUMBER,v_rutusuario varchar2,v_nomapusuario varchar2,v_patente varchar2,v_idtiposerv number,v_idprodvent number,v_rutmecanico varchar2,v_nommec varchar2,v_codproducto number) as
begin
    UPDATE SERVICIO
    SET rut_usuario = v_rutusuario,
        nom_ap_usuario = v_nomapusuario,
        patente_vehiculo = v_patente,
        id_tipo_servicio = v_idtiposerv,
        id_prod_venta = v_idprodvent,
        rut_mecanico = v_rutmecanico,
        nombre_mecanico = v_nommec,
        codigo_producto = v_codproducto
    where   id_servicio = v_idservicio;
    commit;
end;
/
--
-- SP_UPDATE_USUARIO
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_USUARIO" (v_rutusuario varchar2,v_nombreusuario varchar2,v_correo varchar2,v_paswd varchar2,
                                               v_idrol number,v_direccionusuario varchar2,v_telefonousuario varchar2) as
begin
    UPDATE usuario
    SET nom_ap_usuario = v_nombreusuario,
        correo = v_correo,
        paswd = v_paswd,
        id_rol_usuario = v_idrol,
        direccion_usuario = v_direccionusuario,
        telefono_usuario = v_telefonousuario
    where rut_usuario = v_rutusuario;
    commit;
end;
/
--
-- SP_UPDATE_VEHICULO
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_VEHICULO" (v_patente varchar2,v_rutusuario VARCHAR2,v_marca varchar2,v_modelo varchar2,v_anio number) as
begin
    UPDATE vehiculos
    SET rut_usuario = v_rutusuario,
        marca = v_marca,
        modelo = v_modelo,
        anio= v_anio
    where patente = v_patente;
    commit;
end;
/
--
-- SP_UPDATE_VPRODUCTO
--
CREATE OR REPLACE PROCEDURE "SP_UPDATE_VPRODUCTO" (v_idprodventa NUMBER, v_idproducto number,v_cantidad number,v_codproducto number) as
begin
    UPDATE VENTA_PRODUCTO
    SET id_producto = v_idproducto,
        cantidad = v_cantidad,
        codigo_producto = v_codproducto
    where   id_producto_venta = v_idprodventa;
    commit;
end;
/
