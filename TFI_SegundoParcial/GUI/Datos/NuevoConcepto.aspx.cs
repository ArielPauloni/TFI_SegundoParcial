using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

namespace GUI.Datos
{
    public partial class NuevoConcepto : System.Web.UI.Page
    {
        private ConceptoBLL gestorConceptos = new ConceptoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { txtPorcentaje.Text = "0"; }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            int porcentaje = 0;

            try { porcentaje = int.Parse(txtPorcentaje.Text); }
            catch (Exception) { porcentaje = 0; }

            if (!string.IsNullOrWhiteSpace(txtConcepto.Text) && porcentaje > 0)
            {
                ConceptoBE concepto = new ConceptoBE
                {
                    DescripcionConcepto = txtConcepto.Text.Trim(),
                    Porcentaje = porcentaje,
                    EsDescuento = chkEsDescuento.Checked
                };
                if (gestorConceptos.Insertar(concepto) > 0)
                {
                    UC_MensajeModal.SetearMensaje("Datos Salvados correctamente");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
                }
                else
                {
                    UC_MensajeModal.SetearMensaje("No se pudieron grabar correctamente los datos");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
                }
                LimpiarDatos();
            }
            else
            {
                UC_MensajeModal.SetearMensaje("Falta completar algún dato o el dato es incorrecto");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
            }
        }

        private void LimpiarDatos()
        {
            txtConcepto.Text = string.Empty;
            txtPorcentaje.Text = "0";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/Conceptos.aspx");
        }
    }
}