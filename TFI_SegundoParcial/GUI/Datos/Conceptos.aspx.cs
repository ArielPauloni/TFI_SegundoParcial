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
    public partial class Conceptos : System.Web.UI.Page
    {
        private ConceptoBLL gestorConceptos = new ConceptoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnlazarGrillaConceptos();
            }
        }

        private void EnlazarGrillaConceptos()
        {
            grvConcepto.DataSource = gestorConceptos.Listar();
            grvConcepto.DataBind();
            grvConcepto.Columns[1].Visible = false;
        }

        protected void grvConcepto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvConcepto.PageIndex = e.NewPageIndex;
            grvConcepto.EditIndex = -1;
            EnlazarGrillaConceptos();
        }

        protected void grvConcepto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setea EditIndex a -1: Cancela modo edición 
            grvConcepto.EditIndex = -1;
            EnlazarGrillaConceptos();
        }

        protected void grvConcepto_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex se usa para determinar el índice a editar
            grvConcepto.EditIndex = e.NewEditIndex;
            EnlazarGrillaConceptos();
        }

        protected void grvConcepto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Busco los controles de la grilla para la fila que voy a actualizar
            Label id = grvConcepto.Rows[e.RowIndex].FindControl("lbl_codigoConcepto") as Label;

            TextBox txtDescripcionConcepto = grvConcepto.Rows[e.RowIndex].FindControl("txt_DescripcionConcepto") as TextBox;
            TextBox txtPorcentaje = grvConcepto.Rows[e.RowIndex].FindControl("txt_Porcentaje") as TextBox;
            CheckBox chkEsDescuento = grvConcepto.Rows[e.RowIndex].FindControl("chk_EsDescuento") as CheckBox;
            CheckBox chkActivo = grvConcepto.Rows[e.RowIndex].FindControl("chk_Activo") as CheckBox;

            int porcentaje = 0;
            try { porcentaje = int.Parse(txtPorcentaje.Text); }
            catch (Exception) { porcentaje = 0; }

            if (!string.IsNullOrWhiteSpace(txtDescripcionConcepto.Text) &&
                porcentaje > 0)
            {
                ConceptoBE concepto = new ConceptoBE();
                concepto.CodigoConcepto = int.Parse(id.Text);
                concepto.DescripcionConcepto = txtDescripcionConcepto.Text;
                concepto.Porcentaje = int.Parse(txtPorcentaje.Text);
                concepto.EsDescuento = chkEsDescuento.Checked;
                concepto.Activo = chkActivo.Checked;

                int i = gestorConceptos.ActualizarConcepto(concepto);
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
            grvConcepto.EditIndex = -1;
            EnlazarGrillaConceptos();
        }

        protected void grvConcepto_RowDataBound(object sender, GridViewRowEventArgs e)
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

                if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {
                    CheckBox chkEsDescuento = (e.Row.FindControl("chk_EsDescuento") as CheckBox);
                    chkEsDescuento.Enabled = true;

                    CheckBox chkActivo = (e.Row.FindControl("chk_Activo") as CheckBox);
                    chkActivo.Enabled = true;
                }
            }
        }

        protected void btnCrearNuevoConcepto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/NuevoConcepto.aspx");
        }
    }
}