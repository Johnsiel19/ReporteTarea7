using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AnalisisDetalle2.Consultas;

namespace AnalisisDetalle2.Reportes
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cPagos cPagos = new cPagos();
            if (!Page.IsPostBack)//solo se carga si no se esta haciendo postback
            {
                RepositorioBase<Pagos> repositorio = new RepositorioBase<Pagos>();
                var lista = repositorio.GetList(x => true);
                //Indicar que es con reporte local
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                MyReportViewer.Reset();//reiniciar el reporte para evitar que este sucio de una llamada anterior

                //Indicar la ruta del reporte en el servidor
                MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoPagos.rdlc");

                //Agregar una nueva fuente de datos con las categorias que deseamos imprimir
                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Pagos",lista));

                MyReportViewer.LocalReport.Refresh();//Refrescar el reporte para que muestre los datos
            }
        }
    }
}