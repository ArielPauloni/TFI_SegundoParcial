using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CategoriaBE
    {
        private int codigoCategoria;

        public int CodigoCategoria
        {
            get { return codigoCategoria; }
            set { codigoCategoria = value; }
        }

        private string descripcionCategoria;

        public string DescripcionCategoria
        {
            get { return descripcionCategoria; }
            set { descripcionCategoria = value; }
        }

        public override string ToString()
        {
            return DescripcionCategoria;
        }
    }
}
