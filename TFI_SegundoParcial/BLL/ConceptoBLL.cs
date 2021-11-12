using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class ConceptoBLL
    {
        public int Insertar(ConceptoBE concepto)
        {
            ConceptoMapper m = new ConceptoMapper();
            return m.Insertar(concepto);
        }

        public List<ConceptoBE> Listar()
        {
            ConceptoMapper m = new ConceptoMapper();
            return m.Listar();
        }

        public int ActualizarConcepto(ConceptoBE concepto)
        {
            ConceptoMapper m = new ConceptoMapper();
            return m.Actualizar(concepto);
        }

    }
}
