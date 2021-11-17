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
    public partial class NuevaCategoria : System.Web.UI.Page
    {
        private CategoriaBLL gestorCategoria = new CategoriaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCategoria.Text))
            {
                CategoriaBE categoria = new CategoriaBE
                {
                    DescripcionCategoria = txtCategoria.Text.Trim()
                };
                if (gestorCategoria.Insertar(categoria) > 0)
                {
                    UC_MensajeModal.SetearMensaje("Datos Salvados correctamente");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
                }
                else
                {
                    UC_MensajeModal.SetearMensaje("No se pudieron grabar correctamente los datos");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
                }
                txtCategoria.Text = string.Empty;
            }
            else
            {
                UC_MensajeModal.SetearMensaje("Falta completar algún dato o el dato es incorrecto");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/Categorias.aspx");
        }
    }
}