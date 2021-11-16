using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class EmpleadoBLL
    {
        public int Insertar(EmpleadoBE empleado)
        {
            EmpleadoMapper m = new EmpleadoMapper();
            return m.Insertar(empleado);
        }

        public List<EmpleadoBE> Listar()
        {
            EmpleadoMapper m = new EmpleadoMapper();
            return m.Listar();
        }

        public List<EmpleadoReciboBE> ListarEmpleadosRecibos()
        {
            EmpleadoMapper m = new EmpleadoMapper();
            return m.ListarEmpleadosRecibos();
        }

        public int ActualizarEmpleado(EmpleadoBE empleado)
        {
            EmpleadoMapper m = new EmpleadoMapper();
            return m.Actualizar(empleado);
        }

        public EmpleadoReciboBE ObtenerEmpleadoRecibo(ReciboBE recibo)
        {
            ReciboMapper m = new ReciboMapper();
            return m.ObtenerEmpleadoRecibo(recibo);
        }
    }
}
