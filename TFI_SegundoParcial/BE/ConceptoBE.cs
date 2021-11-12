using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ConceptoBE
    {
        private int codigoConcepto;

        public int CodigoConcepto
        {
            get { return codigoConcepto; }
            set { codigoConcepto = value; }
        }

        private string descripcionConcepto;

        public string DescripcionConcepto
        {
            get { return descripcionConcepto; }
            set { descripcionConcepto = value; }
        }

        private int porcentaje;

        public int Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

        private Boolean esDescuento;

        public Boolean EsDescuento
        {
            get { return esDescuento; }
            set { esDescuento = value; }
        }

        private Boolean activo;

        public Boolean Activo
        {
            get { return activo; }
            set { activo = value; }
        }

    }
}
