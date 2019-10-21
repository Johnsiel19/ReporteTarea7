using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using BLL;

namespace AnalisisDetalle2.Registros
{
    public partial class rPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                PacienteIdTextBox.Text = "0";

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Pacientes> repositorio = new BLL.RepositorioBase<Pacientes>();
                    var us = repositorio.Buscar(ID);

                    if (us == null)
                    {
                        Utilitarios.Utils.ShowToastr(this.Page, "Registro No encontrado", "Error", "error");
                    }
                    else
                    {
                        LlenaCampo(us);
                    }
                }
            }

        }

        private void Limpiar()
        {
            PacienteIdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            BalanceTextBox.Text = 0.ToString();
      

        }

        public Pacientes LlenaClase()
        {
            Pacientes paciente = new Pacientes();
            paciente.PacienteId = Convert.ToInt32(PacienteIdTextBox.Text);
            paciente.Nombre = NombreTextBox.Text;
       

            return paciente;
        }

        private void LlenaCampo(Pacientes paciente)
        {
            PacienteIdTextBox.Text = paciente.PacienteId.ToString();
            NombreTextBox.Text = paciente.Nombre;
            BalanceTextBox.Text = paciente.Balance.ToString();

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<TipoAnalisis> db = new RepositorioBase<TipoAnalisis>();
            TipoAnalisis tipoAnalisis = db.Buscar(Convert.ToInt32(PacienteIdTextBox.Text));
            return (tipoAnalisis != null);

        }



        private bool ValidarCampos()
        {
            bool paso = true;
            if (NombreTextBox.Text == string.Empty)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");

                NombreTextBox.Focus();
                paso = false;
            }


            return paso;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            int id;

            RepositorioBase<Pacientes> db = new RepositorioBase<Pacientes>();
            Pacientes tipoAnalisis = new Pacientes();
            int.TryParse(PacienteIdTextBox.Text, out id);
            Limpiar();

            tipoAnalisis = db.Buscar(id);

            if (tipoAnalisis != null)
            {

                LlenaCampo(tipoAnalisis);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro ese tipo de analisis", "Error", "error");

            }

        }

        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Pacientes> db = new RepositorioBase<Pacientes>();
            Pacientes paciente;
            bool paso = false;


            if (!ValidarCampos())
                return;

            paciente = LlenaClase();


            if (PacienteIdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(paciente);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");
                    return;
                }
                paso = db.Modificar(paciente);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            if (Utilitarios.Utils.ToInt(PacienteIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(PacienteIdTextBox.Text);
                RepositorioBase<TipoAnalisis> repositorio = new RepositorioBase<TipoAnalisis>();
                if (repositorio.Eliminar(id))
                {

                    Utilitarios.Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utilitarios.Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar, usuario no existe", "error", "error");
            }

        }
    }
}