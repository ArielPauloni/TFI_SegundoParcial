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
    public partial class Empleados : System.Web.UI.Page
    {
        private EmpleadoBLL gestorEmpleado = new EmpleadoBLL();
        private SueldoBLL gestorSueldo = new SueldoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EnlazarGrillaEmpleados();
            }
        }

        private void EnlazarGrillaEmpleados()
        {
            grvEmpleado.DataSource = gestorEmpleado.Listar();
            grvEmpleado.DataBind();
        }

        protected void grvEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvEmpleado.PageIndex = e.NewPageIndex;
            grvEmpleado.EditIndex = -1;
            EnlazarGrillaEmpleados();
        }

        protected void grvEmpleado_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Setea EditIndex a -1: Cancela modo edición 
            grvEmpleado.EditIndex = -1;
            EnlazarGrillaEmpleados();
        }

        protected void grvEmpleado_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //NewEditIndex se usa para determinar el índice a editar
            grvEmpleado.EditIndex = e.NewEditIndex;
            EnlazarGrillaEmpleados();
        }

        protected void grvEmpleado_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Busco los controles de la grilla para la fila que voy a actualizar
            Label id = grvEmpleado.Rows[e.RowIndex].FindControl("lbl_legajo") as Label;

            TextBox txtApellido = grvEmpleado.Rows[e.RowIndex].FindControl("txt_Apellido") as TextBox;
            TextBox txtNombre = grvEmpleado.Rows[e.RowIndex].FindControl("txt_Nombre") as TextBox;
            TextBox txtFechaIngreso = grvEmpleado.Rows[e.RowIndex].FindControl("txt_FechaIngreso") as TextBox;
            DropDownList ddlSueldo = grvEmpleado.Rows[e.RowIndex].FindControl("ddl_Sueldo") as DropDownList;

            if (!string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtFechaIngreso.Text) && ddlSueldo.SelectedIndex > -1)
            {
                EmpleadoBE empleado = new EmpleadoBE();
                empleado.Legajo = int.Parse(id.Text);
                empleado.Apellido = txtApellido.Text;
                empleado.Nombre = txtNombre.Text;
                empleado.FechaIngreso = Convert.ToDateTime(txtFechaIngreso.Text);
                SueldoBE sueldo = new SueldoBE
                {
                    //Puesto = ddlSueldo.SelectedItem.Text.ToString(),
                    CodigoSueldo = short.Parse(ddlSueldo.SelectedItem.Value)
                };
                empleado.Sueldo = sueldo;
                //empleado.Activo = chkActivo.Checked;

                int i = gestorEmpleado.ActualizarEmpleado(empleado);
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
            grvEmpleado.EditIndex = -1;
            EnlazarGrillaEmpleados();
        }

        protected void grvEmpleado_RowDataBound(object sender, GridViewRowEventArgs e)
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

                Label lbl_legajo = (Label)e.Row.FindControl("lbl_legajo");
                if (lbl_legajo != null)
                { lbl_legajo.Text = lbl_legajo.Text.PadLeft(6, '0'); }

                if ((e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                {
                    DropDownList ddlSueldo = (e.Row.FindControl("ddl_Sueldo") as DropDownList);
                    List<SueldoBE> sueldos = gestorSueldo.Listar();

                    var datasource = from s in sueldos
                                     select new
                                     {
                                         s.CodigoSueldo,
                                         s.Puesto,
                                         s.SueldoBase,
                                         s.Categoria,
                                         DisplayField = s.ToString()
                                     };

                    ddlSueldo.DataSource = datasource;
                    ddlSueldo.DataTextField = "DisplayField";
                    ddlSueldo.DataValueField = "CodigoSueldo";
                    ddlSueldo.DataBind();
                    ddlSueldo.SelectedValue = ((EmpleadoBE)e.Row.DataItem).Sueldo.CodigoSueldo.ToString();

                    if (((EmpleadoBE)e.Row.DataItem).FechaIngreso.HasValue)
                    {
                        TextBox txtFechaIngreso = (e.Row.FindControl("txt_FechaIngreso") as TextBox);
                        txtFechaIngreso.Text = ((EmpleadoBE)e.Row.DataItem).FechaIngreso.Value.ToString("yyyy-MM-dd");
                    }

                    CheckBox chkActivo = (e.Row.FindControl("chk_Activo") as CheckBox);
                    chkActivo.Enabled = true;
                }
            }
        }

        protected void btnCrearNuevoEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/NuevoEmpleado.aspx");
        }
    }
}