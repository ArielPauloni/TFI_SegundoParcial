using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class CategoriaBLL
    {
        public int Insertar(CategoriaBE categoria)
        {
            CategoriaMapper m = new CategoriaMapper();
            return m.Insertar(categoria);
        }

        public List<CategoriaBE> ListarCategorias()
        {
            CategoriaMapper m = new CategoriaMapper();
            return m.ListarCategorias();
        }

        public int ActualizarCategoria(CategoriaBE categoria)
        {
            CategoriaMapper m = new CategoriaMapper();
            return m.Actualizar(categoria);
        }
    }
}
