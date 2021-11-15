using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EmpleadoBE
    {
        private int legajo;

        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private DateTime? fechaIngreso;

        public DateTime? FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        private SueldoBE sueldo;

        public SueldoBE Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
        }


        private List<ReciboBE> recibos;

        public List<ReciboBE> Recibos
        {
            get { return recibos; }
            set { recibos = value; }
        }

        public override string ToString()
        {
            return Legajo.ToString().PadLeft(6, '0') + " - " + Apellido + ", " + Nombre;
        }
    }
}
