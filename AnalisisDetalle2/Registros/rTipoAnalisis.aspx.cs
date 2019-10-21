using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace AnalisisDetalle2.Registros
{
    public partial class rTipoAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                TipoAnalisisIdTextBox.Text = "0";

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<TipoAnalisis> repositorio = new BLL.RepositorioBase<TipoAnalisis>();
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
            TipoAnalisisIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            PrecioTextBox.Text = 0.ToString();
         
        }

        public TipoAnalisis LlenaClase()
        {
            TipoAnalisis tipoanalisis = new TipoAnalisis();
            tipoanalisis.TipoAnalisisId = Convert.ToInt32(TipoAnalisisIdTextBox.Text);
            tipoanalisis.Descripcion = DescripcionTextBox.Text;
            tipoanalisis.Precio = Convert.ToDecimal( PrecioTextBox.Text);

            return tipoanalisis;
        }

        private void LlenaCampo(TipoAnalisis tipoanalisis)
        {
            TipoAnalisisIdTextBox.Text = tipoanalisis.TipoAnalisisId.ToString();
            DescripcionTextBox.Text = tipoanalisis.Descripcion;
            PrecioTextBox.Text = tipoanalisis.Precio.ToString();

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<TipoAnalisis> db = new RepositorioBase<TipoAnalisis>();
            TipoAnalisis tipoAnalisis = db.Buscar(Convert.ToInt32( TipoAnalisisIdTextBox.Text));
            return (tipoAnalisis != null); 

        }



        private bool ValidarCampos()
        {
            bool paso = true;
            if (DescripcionTextBox.Text == string.Empty)
            {
                Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");

                DescripcionTextBox.Focus();
                paso = false;
            }


            return paso;
        }


        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<TipoAnalisis> db = new RepositorioBase<TipoAnalisis>();
            TipoAnalisis tipoanalisis;
            bool paso = false;


            if (!ValidarCampos())
                return;

            tipoanalisis = LlenaClase();


            if (TipoAnalisisIdTextBox.Text == Convert.ToString(0))
            {
                paso = db.Guardar(tipoanalisis);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");
                    return;
                }
                paso = db.Modificar(tipoanalisis);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();


        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            if (Utilitarios.Utils.ToInt(TipoAnalisisIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(TipoAnalisisIdTextBox.Text);
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

        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            int id;

            RepositorioBase<TipoAnalisis> db = new RepositorioBase<TipoAnalisis>();
            TipoAnalisis tipoAnalisis = new TipoAnalisis();
            int.TryParse(TipoAnalisisIdTextBox.Text, out id);
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
    }
}