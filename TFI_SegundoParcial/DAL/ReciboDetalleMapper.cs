using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BE;

namespace DAL
{
    internal class ReciboDetalleMapper
    {
        ConceptoMapper conceptoMapper = new ConceptoMapper();
        internal int Insertar(EmpleadoBE empleado, ReciboBE recibo, ReciboDetalleBE reciboDetalle)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoRecibo", recibo.CodigoRecibo));
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoConcepto", reciboDetalle.Concepto.CodigoConcepto));
            double montoParcial = reciboDetalle.Concepto.Porcentaje * empleado.Sueldo.SueldoBase / 100d;
            if (reciboDetalle.Concepto.EsDescuento) { parametros.Add(AccesoSQL.CrearParametroDecimal("MontoParcial", montoParcial * -1)); }
            else { parametros.Add(AccesoSQL.CrearParametroDecimal("MontoParcial", montoParcial)); }
            parametros.Add(AccesoSQL.CrearParametroInt("Porcentaje", reciboDetalle.Concepto.Porcentaje));
            return AccesoSQL.Escribir("pr_Insertar_ReciboDetalle", parametros);
        }

        internal List<ReciboDetalleBE> ListarReciboDetalle(ReciboBE recibo)
        {
            List<ReciboDetalleBE> myLista = new List<ReciboDetalleBE>();
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoRecibo", recibo.CodigoRecibo));
            DataTable tabla = AccesoSQL.Leer("pr_Listar_ReciboDetalles", parametros);
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    ReciboDetalleBE detalle = new ReciboDetalleBE();
                    ConceptoBE concepto = new ConceptoBE();
                    concepto.CodigoConcepto = int.Parse(fila["CodigoConcepto"].ToString());
                    concepto.DescripcionConcepto = fila["DescripcionConcepto"].ToString();
                    concepto.EsDescuento = (Boolean)(fila["EsDescuento"]);
                    concepto.Porcentaje = int.Parse(fila["Porcentaje"].ToString());
                    detalle.Concepto = concepto;
                    detalle.MontoParcial = double.Parse(fila["MontoParcial"].ToString());

                    myLista.Add(detalle);
                }
            }
            return myLista;
        }
    }
}
