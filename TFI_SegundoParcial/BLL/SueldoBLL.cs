using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class SueldoBLL
    {
        public int Insertar(SueldoBE sueldo)
        {
            SueldoMapper m = new SueldoMapper();
            return m.Insertar(sueldo);
        }

        public List<SueldoBE> Listar()
        {
            SueldoMapper m = new SueldoMapper();
            return m.Listar();
        }

        public List<CategoriaBE> ListarCategorias()
        {
            SueldoMapper m = new SueldoMapper();
            return m.ListarCategorias();
        }

        public int ActualizarSueldo(SueldoBE sueldo)
        {
            SueldoMapper m = new SueldoMapper();
            return m.Actualizar(sueldo);
        }
    }
}
