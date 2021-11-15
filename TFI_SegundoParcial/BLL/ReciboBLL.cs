using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class ReciboBLL
    {
        public int Insertar(EmpleadoBE empleado, ReciboBE recibo)
        {
            ReciboMapper m = new ReciboMapper();
            return m.Insertar(empleado, recibo);
        }
    }
}
