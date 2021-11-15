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
    public partial class NuevoRecibo : System.Web.UI.Page
    {
        private EmpleadoBLL gestorEmpleados = new EmpleadoBLL();
        private ReciboBLL gestorRecibos = new ReciboBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<EmpleadoBE> empleados = gestorEmpleados.Listar();

                var datasource = from emp in empleados
                                 select new
                                 {
                                     emp.Legajo,
                                     emp.Apellido,
                                     emp.Nombre,
                                     DisplayField = emp.ToString()
                                 };

                ddlEmpleado.DataSource = datasource;
                ddlEmpleado.DataTextField = "DisplayField";
                ddlEmpleado.DataValueField = "Legajo";
                ddlEmpleado.DataBind();

                for (int i = 1; i <= 12; i++) { ddlMes.Items.Add(i.ToString().PadLeft(2, '0')); }
                for (int i = 2021; i <= 2026; i++) { ddlAnio.Items.Add(i.ToString()); }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/Recibos.aspx");
        }

        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            EmpleadoBE empSel = new EmpleadoBE { Legajo = short.Parse(ddlEmpleado.SelectedItem.Value) };

            var empleado = gestorEmpleados.Listar().Where(c => c.Legajo == empSel.Legajo).FirstOrDefault();

            string fIngreso = ((EmpleadoBE)empleado).FechaIngreso.Value.Year.ToString() +
                              ((EmpleadoBE)empleado).FechaIngreso.Value.Month.ToString().PadLeft(2, '0');
            string fSel = ddlAnio.SelectedValue + ddlMes.SelectedValue;

            if (string.Compare(fSel, fIngreso) >= 0)
            {
                ReciboBE recibo = new ReciboBE
                {
                    Anio = int.Parse(ddlAnio.SelectedValue),
                    Mes = int.Parse(ddlMes.SelectedValue)
                };
                if (gestorRecibos.Insertar((EmpleadoBE)empleado, recibo) > 0)
                {
                    UC_MensajeModal.SetearMensaje("Datos Salvados correctamente");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
                }
                else
                {
                    UC_MensajeModal.SetearMensaje("No se pudieron grabar correctamente los datos");
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
                }
            }
            else
            {
                UC_MensajeModal.SetearMensaje("En la fecha ingresada el empleado no era parte de la empresa");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
            }
        }
    }
}