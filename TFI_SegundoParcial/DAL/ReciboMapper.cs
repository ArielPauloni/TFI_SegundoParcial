using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class ReciboMapper
    {
        private ReciboDetalleMapper reciboDetalleMapper = new ReciboDetalleMapper();
        private ConceptoMapper conceptoMapper = new ConceptoMapper();

        public int Insertar(EmpleadoBE empleado, ReciboBE recibo)
        {
            int retVal = 0;
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("Anio", recibo.Anio));
            parametros.Add(AccesoSQL.CrearParametroInt("Mes", recibo.Mes));
            //Obtengo los conceptos activos para insertarlos

            List<ReciboDetalleBE> reciboDetalles = new List<ReciboDetalleBE>();
            List<ConceptoBE> conceptos = conceptoMapper.Listar();
            double totalMontoConceptos = 0;
            foreach (ConceptoBE concep in conceptos)
            {
                if (concep.Activo)
                {
                    ReciboDetalleBE reciboDetalle = new ReciboDetalleBE();
                    reciboDetalle.Concepto = concep;
                    if (concep.EsDescuento) { reciboDetalle.MontoParcial = empleado.Sueldo.SueldoBase * concep.Porcentaje / 100d * -1d; }
                    else { reciboDetalle.MontoParcial = empleado.Sueldo.SueldoBase * concep.Porcentaje / 100d; }

                    totalMontoConceptos += reciboDetalle.MontoParcial;
                    reciboDetalles.Add(reciboDetalle);
                }
            }

            parametros.Add(AccesoSQL.CrearParametroDecimal("MontoTotal", empleado.Sueldo.SueldoBase + totalMontoConceptos));
            parametros.Add(AccesoSQL.CrearParametroInt("Legajo", empleado.Legajo));
            DataTable tabla = AccesoSQL.Leer("pr_Insertar_Recibo", parametros);
            if ((tabla != null) && (tabla.Rows.Count > 0))
            {
                try
                {
                    recibo.CodigoRecibo = int.Parse(tabla.Rows[0]["CodigoRecibo"].ToString());
                    recibo.ReciboDetalles = reciboDetalles;
                    //Solo sumo si realmente inserto. Para saber si tengo que borrar o no la venta completa
                    foreach (ReciboDetalleBE det in recibo.ReciboDetalles)
                    { if (reciboDetalleMapper.Insertar(empleado, recibo, det) > 0) { retVal++; } }
                }
                catch (Exception ex)
                {
                    Eliminar(recibo);
                }
                if (retVal == 0) { Eliminar(recibo); }
            }
            return retVal;
        }

        public int Eliminar(ReciboBE recibo)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoRecibo", recibo.CodigoRecibo));
            return AccesoSQL.Escribir("pr_Eliminar_Recibo", parametros);
        }

        public EmpleadoReciboBE ObtenerEmpleadoRecibo(ReciboBE recibo)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoRecibo", recibo.CodigoRecibo));
            DataTable tabla = AccesoSQL.Leer("pr_Listar_Recibo", parametros);
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    EmpleadoReciboBE empRecibo = new EmpleadoReciboBE();
                    EmpleadoBE empleado = new EmpleadoBE();
                    SueldoBE sueldo = new SueldoBE();
                    CategoriaBE categoria = new CategoriaBE();
                    ReciboBE rec = new ReciboBE();

                    categoria.CodigoCategoria = int.Parse(fila["CodigoCategoria"].ToString());
                    categoria.DescripcionCategoria = fila["DescripcionCategoria"].ToString();
                    sueldo.Categoria = categoria;
                    sueldo.CodigoSueldo = int.Parse(fila["CodigoSueldo"].ToString());
                    sueldo.Puesto = fila["Puesto"].ToString();
                    sueldo.SueldoBase = float.Parse(fila["SueldoBase"].ToString());

                    empleado.Legajo = int.Parse(fila["Legajo"].ToString());
                    empleado.Apellido = fila["Apellido"].ToString();
                    empleado.Nombre = fila["Nombre"].ToString();
                    empleado.FechaIngreso = (DateTime)fila["FechaIngreso"];
                    empleado.Sueldo = sueldo;
                    //empleado.Activo = (Boolean)(fila["Activo"]);

                    rec.CodigoRecibo = int.Parse(fila["CodigoRecibo"].ToString());
                    rec.Anio = int.Parse(fila["Anio"].ToString());
                    rec.Mes = int.Parse(fila["Mes"].ToString());
                    rec.MontoTotal = float.Parse(fila["MontoTotal"].ToString());
                    rec.ReciboDetalles = reciboDetalleMapper.ListarReciboDetalle(rec);

                    empRecibo.Empleado = empleado;
                    empRecibo.Recibo = rec;

                    return empRecibo;
                }
            }
            return null;
        }
    }
}
