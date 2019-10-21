using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace AnalisisDetalle2.Consultas
{
    public partial class cPaciente1 : System.Web.UI.Page
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Pacientes, bool>> filtros = x => true;
            RepositorioBase<Pacientes> repositorio = new RepositorioBase<Pacientes>();

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
                        filtros = c => c.PacienteId == id ;
                        break;
                    case 2:
                        filtros = c => c.Nombre.Contains(CriterioTextBox.Text) ;
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
                        filtros = c => c.PacienteId == id;
                        break;
                    case 2:
                        filtros = c => c.Nombre.Contains(CriterioTextBox.Text);
                        break;
                }
            }
            Grid.DataSource = repositorio.GetList(filtros);
            Grid.DataBind();
        }
    }
}