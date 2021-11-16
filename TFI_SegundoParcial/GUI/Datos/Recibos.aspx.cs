using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;

namespace GUI.Datos
{
    public partial class Recibos : System.Web.UI.Page
    {
        private EmpleadoBLL gestorEmpleado = new EmpleadoBLL();

        //private string sortDirByEmpleado
        //{
        //    get { return ViewState["sortDirByEmpleado"] != null ? ViewState["sortDirByEmpleado"].ToString() : "DESC"; }
        //    set { ViewState["sortDirByEmpleado"] = value; }
        //}

        //private string sortDirByPuesto
        //{
        //    get { return ViewState["sortDirByPuesto"] != null ? ViewState["sortDirByPuesto"].ToString() : "DESC"; }
        //    set { ViewState["sortDirByPuesto"] = value; }
        //}

        private string sortDirByAnio
        {
            get { return ViewState["sortDirByAnio"] != null ? ViewState["sortDirByAnio"].ToString() : "DESC"; }
            set { ViewState["sortDirByAnio"] = value; }
        }

        private string sortDirByMes
        {
            get { return ViewState["sortDirByMes"] != null ? ViewState["sortDirByMes"].ToString() : "DESC"; }
            set { ViewState["sortDirByMes"] = value; }
        }

        private string sortDirByMonto
        {
            get { return ViewState["sortDirByMonto"] != null ? ViewState["sortDirByMonto"].ToString() : "DESC"; }
            set { ViewState["sortDirByMonto"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> listaVacia = new List<string>();
                EnlazarGrillaEmpleadosRecibos(listaVacia, string.Empty);
            }
        }

        private void EnlazarGrillaEmpleadosRecibos(List<string> filtros, string orderBy)
        {
            grvEmpleadosRecibos.DataSource = null;
            List<EmpleadoReciboBE> datos = new List<EmpleadoReciboBE>();
            if (filtros.Count == 0) { datos = gestorEmpleado.ListarEmpleadosRecibos(); }
            else
            {
                IEnumerable<EmpleadoReciboBE> filtradosPorEmpleado = null;
                IEnumerable<EmpleadoReciboBE> filtradosPorPuesto = null;
                IEnumerable<EmpleadoReciboBE> filtradosPorAnioDesde = null;
                IEnumerable<EmpleadoReciboBE> filtradosPorAnioHasta = null;
                IEnumerable<EmpleadoReciboBE> filtradosPorMesDesde = null;
                IEnumerable<EmpleadoReciboBE> filtradosPorMesHasta = null;

                //Filtro por empleado
                if (!string.IsNullOrWhiteSpace(filtros[0].ToString()))
                {
                    filtradosPorEmpleado =
                        from EmpleadoReciboBE empRec in gestorEmpleado.ListarEmpleadosRecibos()
                        where empRec.Empleado.ToString() == filtros[0].ToString()
                        select empRec;
                }
                else { filtradosPorEmpleado = gestorEmpleado.ListarEmpleadosRecibos(); }

                //Filtro por puesto (al previamente filtrado por empleado)
                if (!string.IsNullOrWhiteSpace(filtros[1].ToString()))
                {
                    filtradosPorPuesto =
                        from EmpleadoReciboBE empRec in filtradosPorEmpleado
                        where empRec.Empleado.Sueldo.ToString() == filtros[1].ToString()
                        select empRec;
                }
                else { filtradosPorPuesto = filtradosPorEmpleado; }

                //Filtro por Año DESDE (al previamente filtrado por Empleado y puesto)
                if (!string.IsNullOrWhiteSpace(filtros[2].ToString()))
                {
                    filtradosPorAnioDesde =
                        from EmpleadoReciboBE empRec in filtradosPorPuesto
                        where string.Compare(empRec.Recibo.Anio.ToString(), filtros[2].ToString()) >= 0
                        select empRec;
                }
                else { filtradosPorAnioDesde = filtradosPorPuesto; }

                //Filtro por año HASTA (al previamente filtrado por año desde, Empleado y puesto)
                if (!string.IsNullOrWhiteSpace(filtros[3].ToString()))
                {
                    filtradosPorAnioHasta =
                        from EmpleadoReciboBE empRec in filtradosPorAnioDesde
                        where string.Compare(empRec.Recibo.Anio.ToString(), filtros[3].ToString()) <= 0
                        select empRec;
                }
                else { filtradosPorAnioHasta = filtradosPorAnioDesde; }

                //Filtro por mes DESDE (al previamente filtrado por año desde, año hasta, Empleado y puesto)
                if (!string.IsNullOrWhiteSpace(filtros[4].ToString()))
                {
                    filtradosPorMesDesde =
                        from EmpleadoReciboBE empRec in filtradosPorAnioHasta
                        where string.Compare(empRec.Recibo.Mes.ToString(), filtros[4].ToString()) >= 0
                        select empRec;
                }
                else { filtradosPorMesDesde = filtradosPorAnioHasta; }

                //Filtro por mes HASTA (al previamente filtrado por mes desde, año desde, año hasta, Empleado y puesto)
                if (!string.IsNullOrWhiteSpace(filtros[5].ToString()))
                {
                    filtradosPorMesHasta =
                        from EmpleadoReciboBE empRec in filtradosPorMesDesde
                        where string.Compare(empRec.Recibo.Mes.ToString(), filtros[5].ToString()) <= 0
                        select empRec;
                }
                else { filtradosPorMesHasta = filtradosPorMesDesde; }

                //En filtradosPorCriticidad tengo cada uno de los filtros
                foreach (EmpleadoReciboBE empRecFiltrado in filtradosPorMesHasta)
                { datos.Add(empRecFiltrado); }
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                //try
                //{
                //    if (string.Compare("Empleado", orderBy, true) == 0)
                //    {
                //        if (string.Compare("ASC", this.sortDirByEmpleado, true) == 0)
                //        { datos = datos.OrderBy(r => r.Empleado).ToList(); }
                //        else { datos = datos.OrderByDescending(r => r.Empleado).ToList(); }
                //    }

                //    if (string.Compare("Empleado.Sueldo", orderBy, true) == 0)
                //    {
                //        if (string.Compare("ASC", this.sortDirByPuesto, true) == 0)
                //        { datos = datos.OrderBy(r => r.Empleado.Sueldo).ToList(); }
                //        else { datos = datos.OrderByDescending(r => r.Empleado.Sueldo).ToList(); }
                //    }
                //}
                //catch (Exception ex) { }

                if (string.Compare("Recibo.Anio", orderBy, true) == 0)
                {
                    if (string.Compare("ASC", this.sortDirByAnio, true) == 0)
                    { datos = datos.OrderBy(r => r.Recibo.Anio).ToList(); }
                    else { datos = datos.OrderByDescending(r => r.Recibo.Anio).ToList(); }
                }

                if (string.Compare("Recibo.Mes", orderBy, true) == 0)
                {
                    if (string.Compare("ASC", this.sortDirByMes, true) == 0)
                    { datos = datos.OrderBy(r => r.Recibo.Mes).ToList(); }
                    else { datos = datos.OrderByDescending(r => r.Recibo.Mes).ToList(); }
                }

                if (string.Compare("Recibo.MontoTotal", orderBy, true) == 0)
                {
                    if (string.Compare("ASC", this.sortDirByMonto, true) == 0)
                    { datos = datos.OrderBy(r => r.Recibo.MontoTotal).ToList(); }
                    else { datos = datos.OrderByDescending(r => r.Recibo.MontoTotal).ToList(); }
                }
            }

            ListaOrdenable<EmpleadoReciboBE> datosOrdenables = new ListaOrdenable<EmpleadoReciboBE>();
            datosOrdenables = new ListaOrdenable<EmpleadoReciboBE>(datos);
            grvEmpleadosRecibos.DataSource = datosOrdenables;
            grvEmpleadosRecibos.DataBind();

            var empleadosEmpRec = datos.Select(o => o.Empleado.ToString()).Distinct().OrderBy(Empleado => Empleado).ToList();
            List<string> emplStr = new List<string>();
            emplStr.Add(string.Empty);
            foreach (string emp in empleadosEmpRec)
            { emplStr.Add(emp); }
            ddlEmpleados.DataSource = emplStr;
            ddlEmpleados.DataBind();
            if (ddlEmpleados.Items.Count == 2) { ddlEmpleados.SelectedIndex = 1; }

            var anios = datos.Select(o => o.Recibo.Anio.ToString()).Distinct().OrderBy(Anio => Anio).ToList();
            List<string> aniosStr = new List<string>();
            aniosStr.Add(string.Empty);
            foreach (string anio in anios) { aniosStr.Add(anio); }
            ddlAnioDesde.DataSource = aniosStr;
            ddlAnioDesde.DataBind();
            if (ddlAnioDesde.Items.Count == 2) { ddlAnioDesde.SelectedIndex = 1; }
            ddlAnioHasta.DataSource = aniosStr;
            ddlAnioHasta.DataBind();
            if (ddlAnioHasta.Items.Count == 2) { ddlAnioHasta.SelectedIndex = 1; }

            var meses = datos.Select(o => o.Recibo.Mes.ToString()).Distinct().OrderBy(Mes => Mes).ToList();
            List<string> mesesStr = new List<string>();
            mesesStr.Add(string.Empty);
            foreach (string mes in meses) { mesesStr.Add(mes.ToString()); }
            ddlMesDesde.DataSource = mesesStr;
            ddlMesDesde.DataBind();
            if (ddlMesDesde.Items.Count == 2) { ddlMesDesde.SelectedIndex = 1; }
            ddlMesHasta.DataSource = mesesStr;
            ddlMesHasta.DataBind();
            if (ddlMesHasta.Items.Count == 2) { ddlMesHasta.SelectedIndex = 1; }

            var puestos = datos.Select(o => o.Empleado.Sueldo.ToString()).Distinct().OrderBy(Sueldo => Sueldo).ToList();
            List<string> puestosStr = new List<string>();
            puestosStr.Add(string.Empty);
            foreach (string eventoBitacora in puestos) { puestosStr.Add(eventoBitacora); }
            ddlSueldo.DataSource = puestosStr;
            ddlSueldo.DataBind();
            if (ddlSueldo.Items.Count == 2) { ddlSueldo.SelectedIndex = 1; }
        }

        protected void grvEmpleadosRecibos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton btnSort = (LinkButton)e.Row.Cells[2].Controls[0];
                //btnSort.Text = "Empleado";
                //btnSort = (LinkButton)e.Row.Cells[1].Controls[0];
                //btnSort.Text = "Puesto (Categoría)";
                //btnSort = (LinkButton)e.Row.Cells[2].Controls[0];
                btnSort.Text = "Año";
                btnSort = (LinkButton)e.Row.Cells[3].Controls[0];
                btnSort.Text = "Mes";
                btnSort = (LinkButton)e.Row.Cells[4].Controls[0];
                btnSort.Text = "Sueldo Neto";
            }
        }

        protected void btnCrearNuevoRecibo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/NuevoRecibo.aspx");
        }

        protected void grvEmpleadosRecibos_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<string> filtros = new List<string>();
            filtros.Add(ddlEmpleados.SelectedItem.ToString());
            filtros.Add(ddlSueldo.SelectedItem.ToString());
            filtros.Add(ddlAnioDesde.SelectedItem.ToString());
            filtros.Add(ddlAnioHasta.SelectedItem.ToString());
            filtros.Add(ddlMesDesde.SelectedItem.ToString());
            filtros.Add(ddlMesHasta.SelectedItem.ToString());

            //if (string.Compare("Empleado", e.SortExpression, true) == 0)
            //{ this.sortDirByEmpleado = this.sortDirByEmpleado == "ASC" ? "DESC" : "ASC"; }

            //if (string.Compare("Empleado.Sueldo", e.SortExpression, true) == 0)
            //{ this.sortDirByPuesto = this.sortDirByPuesto == "ASC" ? "DESC" : "ASC"; }

            if (string.Compare("Recibo.Anio", e.SortExpression, true) == 0)
            { this.sortDirByAnio = this.sortDirByAnio == "ASC" ? "DESC" : "ASC"; ; }

            if (string.Compare("Recibo.Mes", e.SortExpression, true) == 0)
            { this.sortDirByMes = this.sortDirByMes == "ASC" ? "DESC" : "ASC"; }

            if (string.Compare("Recibo.MontoTotal", e.SortExpression, true) == 0)
            { this.sortDirByMonto = this.sortDirByMonto == "ASC" ? "DESC" : "ASC"; }

            EnlazarGrillaEmpleadosRecibos(filtros, e.SortExpression);
        }

        protected void btnLimpiarFiltros_ServerClick(object sender, EventArgs e)
        {
            List<string> listaVacia = new List<string>();
            EnlazarGrillaEmpleadosRecibos(listaVacia, string.Empty);
        }

        protected void btnFiltrar_ServerClick(object sender, EventArgs e)
        {
            List<string> filtros = new List<string>();
            filtros.Add(ddlEmpleados.SelectedItem.ToString());
            filtros.Add(ddlSueldo.SelectedItem.ToString());
            filtros.Add(ddlAnioDesde.SelectedItem.ToString());
            filtros.Add(ddlAnioHasta.SelectedItem.ToString());
            filtros.Add(ddlMesDesde.SelectedItem.ToString());
            filtros.Add(ddlMesHasta.SelectedItem.ToString());

            EnlazarGrillaEmpleadosRecibos(filtros, string.Empty);
        }

        protected void btnVerRecibo_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow grv = (GridViewRow)btn.NamingContainer;

            Response.Redirect("~/Datos/VerReciboDetalle.aspx?CodigoRecibo=" + grvEmpleadosRecibos.Rows[grv.RowIndex].Cells[5].Text);
        }
    }
}