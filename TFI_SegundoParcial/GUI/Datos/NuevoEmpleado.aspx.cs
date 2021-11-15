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
    public partial class NuevoEmpleado : System.Web.UI.Page
    {
        private EmpleadoBLL gestorEmpleados = new EmpleadoBLL();
        private SueldoBLL gestorSueldo = new SueldoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

                txtFechaIngreso.Text = "2021-01-01";
            }
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            Nullable<DateTime> fNull = default(DateTime?);

            try { fNull = Convert.ToDateTime(txtFechaIngreso.Text); }
            catch (Exception) { }

            if (!string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                ddlSueldo.SelectedIndex > -1 && fNull.HasValue)
            {
                SueldoBE sueldo = new SueldoBE
                {
                    //Puesto = ddlSueldo.SelectedItem.Text.ToString(),
                    CodigoSueldo = short.Parse(ddlSueldo.SelectedItem.Value)
                };
                EmpleadoBE empleado = new EmpleadoBE
                {
                    Apellido = txtApellido.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    FechaIngreso = fNull.Value,
                    Sueldo = sueldo
                };
                if (gestorEmpleados.Insertar(empleado) > 0)
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
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtFechaIngreso.Text = "2021-01-01";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/Empleados.aspx");
        }
    }
}