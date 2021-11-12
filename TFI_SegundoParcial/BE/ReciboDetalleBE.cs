using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ReciboDetalleBE
    {
        private ConceptoBE concepto;

        public ConceptoBE Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }

        private float montoParcial;

        public float MontoParcial
        {
            get { return montoParcial; }
            set { montoParcial = value; }
        }


    }
}
