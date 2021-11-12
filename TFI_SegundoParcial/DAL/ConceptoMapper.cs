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
    public class ConceptoMapper
    {
        public int Insertar(ConceptoBE concepto)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroStr("DescripcionConcepto", concepto.DescripcionConcepto));
            parametros.Add(AccesoSQL.CrearParametroInt("Porcentaje", concepto.Porcentaje));
            parametros.Add(AccesoSQL.CrearParametroBit("EsDescuento", concepto.EsDescuento));
            return AccesoSQL.Escribir("pr_Insertar_Concepto", parametros);
        }

        public int Actualizar(ConceptoBE concepto)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoConcepto", concepto.CodigoConcepto));
            parametros.Add(AccesoSQL.CrearParametroStr("DescripcionConcepto", concepto.DescripcionConcepto));
            parametros.Add(AccesoSQL.CrearParametroInt("Porcentaje", concepto.Porcentaje));
            parametros.Add(AccesoSQL.CrearParametroBit("EsDescuento", concepto.EsDescuento));
            parametros.Add(AccesoSQL.CrearParametroBit("Activo", concepto.Activo));
            return AccesoSQL.Escribir("pr_Actualizar_Concepto", parametros);
        }

        public List<ConceptoBE> Listar()
        {
            List<ConceptoBE> listaConceptos = new List<ConceptoBE>();
            AccesoSQL AccesoSQL = new AccesoSQL();
            DataTable tabla = AccesoSQL.Leer("pr_Listar_Conceptos", null);
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    ConceptoBE concepto = new ConceptoBE();
                    concepto.CodigoConcepto = int.Parse(fila["CodigoConcepto"].ToString());
                    concepto.DescripcionConcepto = fila["DescripcionConcepto"].ToString();
                    concepto.Porcentaje = int.Parse(fila["Porcentaje"].ToString());
                    concepto.EsDescuento = (Boolean)(fila["EsDescuento"]);
                    concepto.Activo = (Boolean)(fila["Activo"]);

                    listaConceptos.Add(concepto);
                }
            }
            return listaConceptos;
        }
    }
}
