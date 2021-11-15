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
    public class EmpleadoMapper
    {
        public List<EmpleadoBE> Listar()
        {
            List<EmpleadoBE> listaEmpleados = new List<EmpleadoBE>();
            AccesoSQL AccesoSQL = new AccesoSQL();
            DataTable tabla = AccesoSQL.Leer("pr_Listar_Empleados", null);
            if (tabla != null)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    EmpleadoBE empleado = new EmpleadoBE();
                    SueldoBE sueldo = new SueldoBE();
                    CategoriaBE categoria = new CategoriaBE();
                    
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

                    listaEmpleados.Add(empleado);
                }
            }
            return listaEmpleados;
        }

        public int Insertar(EmpleadoBE empleado)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroStr("Apellido", empleado.Apellido));
            parametros.Add(AccesoSQL.CrearParametroStr("Nombre", empleado.Nombre));
            parametros.Add(AccesoSQL.CrearParametroDate("FechaIngreso", empleado.FechaIngreso));
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoSueldo", empleado.Sueldo.CodigoSueldo));
            return AccesoSQL.Escribir("pr_Insertar_Empleado", parametros);
        }

        public int Actualizar(EmpleadoBE empleado)
        {
            AccesoSQL AccesoSQL = new AccesoSQL();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(AccesoSQL.CrearParametroInt("Legajo", empleado.Legajo));
            parametros.Add(AccesoSQL.CrearParametroStr("Apellido", empleado.Apellido));
            parametros.Add(AccesoSQL.CrearParametroStr("Nombre", empleado.Nombre));
            parametros.Add(AccesoSQL.CrearParametroDate("FechaIngreso", empleado.FechaIngreso));
            parametros.Add(AccesoSQL.CrearParametroInt("CodigoSueldo", empleado.Sueldo.CodigoSueldo));
            //parametros.Add(AccesoSQL.CrearParametroBit("Activo", empleado.Activo));
            return AccesoSQL.Escribir("pr_Actualizar_Empleado", parametros);
        }
    }
}
