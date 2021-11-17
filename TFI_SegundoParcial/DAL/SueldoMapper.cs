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
    public class SueldoMapper
    {
        public int Insertar(SueldoBE sueldo)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoCategoria", sueldo.Categoria.CodigoCategoria));
            parametros.Add(AccesoSQL.CrearParametroDecimal("SueldoBase", sueldo.SueldoBase));
            parametros.Add(AccesoSQL.CrearParametroStr("Puesto", sueldo.Puesto));
            return AccesoSQL.Escribir("pr_Insertar_Sueldo", parametros);
        }

        public int Actualizar(SueldoBE sueldo)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoSueldo", sueldo.CodigoSueldo));
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoCategoria", sueldo.Categoria.CodigoCategoria));
            parametros.Add(AccesoSQL.CrearParametroDecimal("SueldoBase", sueldo.SueldoBase));
            parametros.Add(AccesoSQL.CrearParametroStr("Puesto", sueldo.Puesto));
            return AccesoSQL.Escribir("pr_Actualizar_Sueldo", parametros);
        }

        public List<SueldoBE> Listar()
        {
            List<SueldoBE> listaSueldos = new List<SueldoBE>();
            AccesoSQL AccesoSQL = new AccesoSQL();
            DataTable tabla = AccesoSQL.Leer("pr_Listar_Sueldos", null);
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    SueldoBE sueldo = new SueldoBE();
                    sueldo.CodigoSueldo = int.Parse(fila["CodigoSueldo"].ToString());
                    sueldo.SueldoBase = float.Parse(fila["SueldoBase"].ToString());
                    sueldo.Puesto = fila["Puesto"].ToString();
                    CategoriaBE categoria = new CategoriaBE();
                    categoria.CodigoCategoria = int.Parse(fila["CodigoCategoria"].ToString());
                    categoria.DescripcionCategoria = fila["DescripcionCategoria"].ToString();
                    sueldo.Categoria = categoria;

                    listaSueldos.Add(sueldo);
                }
            }
            return listaSueldos;
        }
    }
}
