using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EmpleadoReciboBE
    {
        private EmpleadoBE empleado;

        public EmpleadoBE Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }

        private ReciboBE recibo;

        public ReciboBE Recibo
        {
            get { return recibo; }
            set { recibo = value; }
        }
    }
}
