using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BE;
using System.Data;

namespace GUI.Datos
{
    public partial class VerReciboDetalle : System.Web.UI.Page
    {
        private EmpleadoBLL gestorEmpleado = new EmpleadoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CodigoRecibo"] != null && Request.QueryString["CodigoRecibo"] != string.Empty)
                {
                    ReciboBE recibo = new ReciboBE();
                    recibo.CodigoRecibo = int.Parse(Request.QueryString["CodigoRecibo"].ToString());
                    EmpleadoReciboBE empRec = gestorEmpleado.ObtenerEmpleadoRecibo(recibo);

                    if (empRec != null)
                    {
                        List<ReciboDetalleBE> recDet = new List<ReciboDetalleBE>();
                        ReciboDetalleBE red = new ReciboDetalleBE();
                        ConceptoBE concep = new ConceptoBE();
                        red.MontoParcial = empRec.Empleado.Sueldo.SueldoBase;
                        concep.DescripcionConcepto = "Sueldo Base";
                        red.Concepto = concep;
                        recDet.Add(red);
                        foreach (ReciboDetalleBE r in empRec.Recibo.ReciboDetalles) { recDet.Add(r); }

                        grvEmpleadoRecibo.DataSource = recDet;
                        grvEmpleadoRecibo.DataBind();

                        string datosEmp = SetearDatos(empRec.Empleado);
                        string periodo = SetearPeriodo(empRec.Recibo);
                        string totalACobrar = "Total a Cobrar: $ " + empRec.Recibo.MontoTotal.ToString("N2") + "\r\n";
                        DatosEmpleado.Text = datosEmp.Substring(0, datosEmp.Length -11) + periodo + "\r\n" + totalACobrar;
                    }
                }
            }
        }

        protected void btnImprimirPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["CodigoRecibo"] != null && Request.QueryString["CodigoRecibo"] != string.Empty)
                {
                    ReciboBE recibo = new ReciboBE();
                    recibo.CodigoRecibo = int.Parse(Request.QueryString["CodigoRecibo"].ToString());
                    EmpleadoReciboBE empRec = gestorEmpleado.ObtenerEmpleadoRecibo(recibo);

                    if (empRec != null)
                    {
                        string tmpPath = Server.MapPath("~/PDFs/");
                        string nombreRecibo = String.Format("{0} {1}-{2}." + "PDF", empRec.Empleado.ToString(),
                            empRec.Recibo.Anio.ToString(), empRec.Recibo.Mes.ToString().PadLeft(2, '0')).Replace(' ', '_');
                        string filename = nombreRecibo;

                        string periodo = SetearPeriodo(empRec.Recibo);
                        string datosEmp = SetearDatos(empRec.Empleado);
                        string totalACobrar = "Total a Cobrar: $ " + empRec.Recibo.MontoTotal.ToString("N2") + "\r\n";

                        DataTable dt = GetDataTable(grvEmpleadoRecibo);
                        ReportePDF.GuardarPDF(tmpPath + @"\" + filename, empRec.Empleado.ToString(), periodo, datosEmp, dt, totalACobrar, "Pág. {0} de {1}");
                        //Response.Redirect("~/DownloadFile.ashx?filename=" + filename);
                    }
                }
            }
            catch (Exception ex)
            {
                UC_MensajeModal.SetearMensaje("Error: " + ex.Message);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "mostrarMensaje()", true);
            }
        }

        private string SetearDatos(EmpleadoBE emp)
        {
            string retStr = "Legajo: " + emp.Legajo.ToString().PadLeft(6, '0') + "\r\n";
            retStr += "Apellido, Nombre: " + emp.Apellido + ", " + emp.Nombre + "\r\n";
            retStr += "Puesto: " + emp.Sueldo.Puesto + "\r\n";
            retStr += "Categoría: " + emp.Sueldo.Categoria.DescripcionCategoria + "\r\n";
            retStr += "Detalle:" + "\r\n";

            return retStr;
        }

        private string SetearPeriodo(ReciboBE recibo)
        {
            string retStr = "Período Liquidado: ";

            switch (recibo.Mes)
            {
                case 1:
                    retStr += "Enero";
                    break;
                case 2:
                    retStr += "Febrero";
                    break;
                case 3:
                    retStr += "Marzo";
                    break;
                case 4:
                    retStr += "Abril";
                    break;
                case 5:
                    retStr += "Mayo";
                    break;
                case 6:
                    retStr += "Junio";
                    break;
                case 7:
                    retStr += "Julio";
                    break;
                case 8:
                    retStr += "Agosto";
                    break;
                case 9:
                    retStr += "Septiembre";
                    break;
                case 10:
                    retStr += "Octubre";
                    break;
                case 11:
                    retStr += "Noviembre";
                    break;
                case 12:
                    retStr += "Diciembre";
                    break;
            }

            retStr += " " + recibo.Anio;
            return retStr;
        }

        DataTable GetDataTable(GridView dtg)
        {
            DataTable dt = new DataTable();

            // add the columns to the datatable            
            if (dtg.HeaderRow != null)
            {
                for (int i = 0; i < dtg.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(dtg.HeaderRow.Cells[i].Text);
                }
            }
            //  add each of the data rows to the table
            foreach (GridViewRow row in dtg.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();
                int j = 0;
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[j] = HttpUtility.HtmlDecode(row.Cells[i].Text);
                    j++;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Datos/Recibos.aspx");
        }

        protected void grvEmpleadoRecibo_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}