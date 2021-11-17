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
    public partial class NuevoSueldo : System.Web.UI.Page
    {
        private SueldoBLL gestorSueldos = new SueldoBLL();
        private CategoriaBLL gestorCategorias = new CategoriaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategoria.DataSource = gestorCategorias.ListarCategorias();
                ddlCategoria.DataTextField = "DescripcionCategoria";
                ddlCategoria.DataValueField = "CodigoCategoria";
                ddlCategoria.DataBind();
                CategoriaBE categoria = new CategoriaBE
                {
                    DescripcionCategoria = ddlCategoria.SelectedItem.Text.ToString(),
                    CodigoCategoria = short.Parse(ddlCategoria.SelectedItem.Value)
                };
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            float sueldoBase = 0;

            try { sueldoBase = float.Parse(txtSueldoBase.Text); }
            catch (Exception) { sueldoBase = 0; }

            if (ddlCategoria.SelectedIndex > -1 && sueldoBase > 0 && !string.IsNullOrWhiteSpace(txtPuesto.Text))
            {
                CategoriaBE categoria = new CategoriaBE
                {
                    DescripcionCategoria = ddlCategoria.SelectedItem.Text.ToString(),
                    CodigoCategoria = short.Parse(ddlCategoria.SelectedItem.Value)
                };
                SueldoBE sueldo = new SueldoBE
                {
                    Categoria = categoria,
                    SueldoBase = sueldoBase,
                    Puesto = txtPuesto.Text.Trim()
                };
                if (gestorSueldos.Insertar(sueldo) > 0)
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
            txtPuesto.Text = string.Empty;
            txtSueldoBase.Text = "0";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/Sueldos.aspx");
        }
    }
}