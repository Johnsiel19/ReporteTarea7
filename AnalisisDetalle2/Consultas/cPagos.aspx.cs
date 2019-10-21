using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;

namespace AnalisisDetalle2.Consultas
{
    public partial class cPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepositorioBase<Pacientes> repositorio = new RepositorioBase<Pacientes>();
            if (!Page.IsPostBack)
            {
                DesdeFecha.Text = DateTime.Today.ToString("dd-MM-yyyy");
                HastaFecha.Text = DateTime.Today.ToString("dd-MM-yyyy");


            }

            
        }

        public List<Pagos> Lista;

       public System.Linq.Expressions.Expression<Func<Pagos, bool>> filtros = x => true;
        protected void ConsultarButton_Click(object sender, EventArgs e)
        {
           
            RepositorioBase<Pagos> repositorio = new RepositorioBase<Pagos>();

            DateTime Desde = Utilitarios.Utils.ToDateTime(DesdeFecha.Text);
            DateTime Hasta = Utilitarios.Utils.ToDateTime(HastaFecha.Text);

            int id;
            id = Utilitarios.Utils.ToInt(CriterioTextBox.Text);

            if (CheckBoxFecha.Checked == true)
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        filtros = c => c.PagoId== id;
                        break;
                    case 2:
                        filtros = c => c.PacienteId == id;
                        break;
                    case 3:
                        filtros = c => c.MontoPagado == id;
                        break;
                }
            }
            else
            {
                switch (FiltroDropDown.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        filtros = c => c.PagoId == id;
                        break;
                    case 2:
                        filtros = c => c.PacienteId == id;
                        break;
                    case 3:
                        filtros = c => c.MontoPagado == id;
                        break;
                }
            }
            Grid.DataSource = repositorio.GetList(filtros);
            Lista = repositorio.GetList(filtros);
            Grid.DataBind();
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\Reportes\ReportViewer.aspx");

        }
    }
    


}