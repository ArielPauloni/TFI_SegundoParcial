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
    public partial class Categorias : System.Web.UI.Page
    {
        private CategoriaBLL gestorCategorias = new CategoriaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnlazarGrillaCategorias();
            }
        }

        private void EnlazarGrillaCategorias()
        {
            grvCategoria.DataSource = gestorCategorias.ListarCategorias();
            grvCategoria.DataBind();
            grvCategoria.Columns[1].Visible = false;
        }

        protected void btnCrearNuevaCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/NuevaCategoria.aspx");
        }

        protected void grvCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvCategoria.PageIndex = e.NewPageIndex;
            grvCategoria.EditIndex = -1;
            EnlazarGrillaCategorias();
        }

        protected void grvCategoria_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvCategoria.EditIndex = e.NewEditIndex;
            EnlazarGrillaCategorias();
        }

        protected void grvCategoria_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Busco los controles de la grilla para la fila que voy a actualizar
            Label id = grvCategoria.Rows[e.RowIndex].FindControl("lbl_codigoCategoria") as Label;

            TextBox txtDescripcionCategoria = grvCategoria.Rows[e.RowIndex].FindControl("txt_DescripcionCategoria") as TextBox;

            if (!string.IsNullOrWhiteSpace(txtDescripcionCategoria.Text))
            {
                CategoriaBE categoria = new CategoriaBE();
                categoria.CodigoCategoria = int.Parse(id.Text);
                categoria.DescripcionCategoria = txtDescripcionCategoria.Text;
               
                int i = gestorCategorias.ActualizarCategoria(categoria);
                if (i == 0)
                {
                    UC_MensajeModal.SetearMensaje("No se pudo actualizar el dato");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
                }
                else
                {
                    UC_MensajeModal.SetearMensaje("Datos Salvados correctamente");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
                }
            }
            else
            {
                UC_MensajeModal.SetearMensaje("Datos incorrectos");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
            }
            grvCategoria.EditIndex = -1;
            EnlazarGrillaCategorias();
        }

        protected void grvCategoria_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton controlEdit = (LinkButton)e.Row.FindControl("btn_Edit");
                if (controlEdit != null) { controlEdit.ToolTip = "Editar"; }

                LinkButton controlUpdate = (LinkButton)e.Row.FindControl("btn_Update");
                if (controlUpdate != null)
                { controlUpdate.ToolTip = "Confirmar"; }

                LinkButton controlUndo = (LinkButton)e.Row.FindControl("btn_Undo");
                if (controlUndo != null)
                { controlUndo.ToolTip = "Deshacer"; }
            }
        }

        protected void grvCategoria_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvCategoria.EditIndex = -1;
            EnlazarGrillaCategorias();
        }
    }
}