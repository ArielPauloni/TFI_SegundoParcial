using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ReciboBE
    {
        private int codigoRecibo;

        public int CodigoRecibo
        {
            get { return codigoRecibo; }
            set { codigoRecibo = value; }
        }

        private int anio;

        public int Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        private int mes;

        public int Mes
        {
            get { return mes; }
            set { mes = value; }
        }

        private List<ReciboDetalleBE> reciboDetalles;

        public List<ReciboDetalleBE> ReciboDetalles
        {
            get { return reciboDetalles; }
            set { reciboDetalles = value; }
        }
        
        private float montoTotal;

        public float MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }
    }
}
