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
    public class CategoriaMapper
    {
        public int Insertar(CategoriaBE categoria)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroStr("DescripcionCategoria", categoria.DescripcionCategoria));
            return AccesoSQL.Escribir("pr_Insertar_Categoria", parametros);
        }

        public int Actualizar(CategoriaBE categoria)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoCategoria", categoria.CodigoCategoria));
            parametros.Add(AccesoSQL.CrearParametroStr("DescripcionCategoria", categoria.DescripcionCategoria));
            return AccesoSQL.Escribir("pr_Actualizar_Categoria", parametros);
        }

        public List<CategoriaBE> ListarCategorias()
        {
            List<CategoriaBE> listaCategorias = new List<CategoriaBE>();
            AccesoSQL AccesoSQL = new AccesoSQL();
            DataTable tabla = AccesoSQL.Leer("pr_Listar_Categorias", null);
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    CategoriaBE categoria = new CategoriaBE();
                    categoria.CodigoCategoria = int.Parse(fila["CodigoCategoria"].ToString());
                    categoria.DescripcionCategoria = fila["DescripcionCategoria"].ToString();

                    listaCategorias.Add(categoria);
                }
            }
            return listaCategorias;
        }
    }
}
