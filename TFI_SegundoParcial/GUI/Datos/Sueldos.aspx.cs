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
    public partial class Sueldos : System.Web.UI.Page
    {
        private SueldoBLL gestorSueldo = new SueldoBLL();
        private CategoriaBLL gestorCategoria = new CategoriaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnlazarGrillaSueldos();
            }
        }

        private void EnlazarGrillaSueldos()
        {
            grvSueldo.DataSource = gestorSueldo.Listar();
            grvSueldo.DataBind();
            grvSueldo.Columns[1].Visible = false;
        }

        protected void grvSueldo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvSueldo.PageIndex = e.NewPageIndex;
            grvSueldo.EditIndex = -1;
            EnlazarGrillaSueldos();
        }

        protected void grvSueldo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setea EditIndex a -1: Cancela modo edición 
            grvSueldo.EditIndex = -1;
            EnlazarGrillaSueldos();
        }

        protected void grvSueldo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex se usa para determinar el índice a editar
            grvSueldo.EditIndex = e.NewEditIndex;
            EnlazarGrillaSueldos();
        }

        protected void grvSueldo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Busco los controles de la grilla para la fila que voy a actualizar
            Label id = grvSueldo.Rows[e.RowIndex].FindControl("lbl_codigoSueldo") as Label;

            DropDownList ddlCategoria = grvSueldo.Rows[e.RowIndex].FindControl("ddl_Categoria") as DropDownList;
            TextBox txtSueldoBase = grvSueldo.Rows[e.RowIndex].FindControl("txt_SueldoBase") as TextBox;
            TextBox txtPuesto = grvSueldo.Rows[e.RowIndex].FindControl("txt_Puesto") as TextBox;
            
            float sueldoBase = 0;
            try { sueldoBase = float.Parse(txtSueldoBase.Text); }
            catch (Exception) { sueldoBase = 0; }

            if (ddlCategoria.SelectedIndex > -1 && !string.IsNullOrWhiteSpace(txtPuesto.Text) &&
                sueldoBase > 0)
            {
                SueldoBE sueldo = new SueldoBE();
                sueldo.CodigoSueldo = int.Parse(id.Text);
                CategoriaBE categoria = new CategoriaBE
                {
                    DescripcionCategoria = ddlCategoria.SelectedItem.Text.ToString(),
                    CodigoCategoria = short.Parse(ddlCategoria.SelectedItem.Value)
                };
                sueldo.Categoria = categoria;
                sueldo.Puesto = txtPuesto.Text;
                sueldo.SueldoBase = sueldoBase;

                int i = gestorSueldo.ActualizarSueldo(sueldo);
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
            grvSueldo.EditIndex = -1;
            EnlazarGrillaSueldos();
        }

        protected void grvSueldo_RowDataBound(object sender, GridViewRowEventArgs e)
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
            if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
            {
                DropDownList ddlCategoria = (e.Row.FindControl("ddl_Categoria") as DropDownList);
                ddlCategoria.DataSource = gestorCategoria.ListarCategorias();
                ddlCategoria.DataTextField = "DescripcionCategoria";
                ddlCategoria.DataValueField = "CodigoCategoria";
                ddlCategoria.DataBind();
                ddlCategoria.SelectedValue = ((SueldoBE)e.Row.DataItem).Categoria.CodigoCategoria.ToString();
            }
        }

        protected void btnCrearNuevoSueldo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/NuevoSueldo.aspx");
        }
    }
}