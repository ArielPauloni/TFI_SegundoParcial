using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SueldoBE
    {
        private int codigoSueldo;

        public int CodigoSueldo
        {
            get { return codigoSueldo; }
            set { codigoSueldo = value; }
        }

        private string categoria;

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private string puesto;

        public string Puesto
        {
            get { return puesto; }
            set { puesto = value; }
        }

        private float sueldoBase;

        public float SueldoBase
        {
            get { return sueldoBase; }
            set { sueldoBase = value; }
        }
    }
}
