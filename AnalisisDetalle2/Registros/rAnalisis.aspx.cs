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
    public partial class rAnalisis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            

            if (!Page.IsPostBack)
            {
                CargarTipoAnalisis();
                CargarPacientes();
                AnalisisIdNumericUpDown.Text = "0";
                PrecioTextBox.Text = "0";
                BalanceTextBox.Text = "0";
                MontoTextBox.Text= "0";
                ViewState["Analisis"] = new Analisis();
                // ViewState["Detalle"] = new Pagos().Detalle;
                BindGrid();

            }

            int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

            if (ID > 0)
            {
                BLL.RepositorioBase<Analisis> repositorio = new BLL.RepositorioBase<Analisis>();
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

        private void CargarTipoAnalisis()
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<TipoAnalisis> db = new RepositorioBase<TipoAnalisis>();


                TiposAnalisisDropDown.DataSource = db.GetList(t => true);
                TiposAnalisisDropDown.DataValueField = "TipoAnalisisId";
                TiposAnalisisDropDown.DataTextField = "Descripcion";
                TiposAnalisisDropDown.DataBind();

                ViewState["Analisis"] = new Analisis();
            }

        }

        private void CargarPacientes()
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<Pacientes> db = new RepositorioBase<Pacientes>();


                PacienteDropDownList.DataSource = db.GetList(t => true);
                PacienteDropDownList.DataValueField = "PacienteId"; 
                PacienteDropDownList.DataTextField = "Nombre";
                PacienteDropDownList.DataBind();

                ViewState["Analisis"] = new Analisis();
            }

        }

        protected void AgregarGrid_Click(object sender, EventArgs e)
        {
            Analisis analisis = new Analisis();

            analisis = (Analisis)ViewState["Analisis"];
   
            //pago.Detalle.Add(new Entidades.PagosDetalle(0,0, Convert.ToDateTime(FechaTextBox.Text),Convert.ToDecimal( MontoAnalisisTextBox.Text),0,Convert.ToDecimal( MontoAPagarTextBox.Text)));
            analisis.Detalle.Add(new Entidades.AnalisisDetalle(0,0,
                Convert.ToInt32( TiposAnalisisDropDown.SelectedValue), 
                ResultadoTextBox.Text,Convert.ToDecimal(PrecioTextBox.Text)));

            ViewState["Analisis"] = analisis;

            this.BindGrid();

            Grid.Columns[1].Visible = false;
            MontoTextBox.Text = string.Empty;
           
            decimal Calculador = 0;
            foreach (var item in analisis.Detalle)
            {
                Calculador =  Calculador + item.Precio;
            }
            MontoTextBox.Text = Calculador.ToString();
            BalanceTextBox.Text = Convert.ToString(Convert.ToDecimal(BalanceTextBox.Text) + Convert.ToDecimal(PrecioTextBox.Text));
            ResultadoTextBox.Text = string.Empty;
        }
        protected void BindGrid()
        {
            if (ViewState["Analisis"] != null)
            {
                Grid.DataSource = ((Analisis)ViewState["Analisis"]).Detalle;
                Grid.DataBind();


            }
        }

        protected void TiposAnalisisDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<TipoAnalisis> db = new RepositorioBase<TipoAnalisis>();
            TipoAnalisis analisis = new TipoAnalisis();
            int.TryParse(TiposAnalisisDropDown.SelectedValue, out id);
        

            analisis = db.Buscar(id);

            PrecioTextBox.Text = Convert.ToString(analisis.Precio);


        }

        protected void TiposAnalisisDropDown_TextChanged(object sender, EventArgs e)
        {

      

        }

        private void Limpiar()
        {
            AnalisisIdNumericUpDown.Text = "0";
           
       
            ResultadoTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            Grid.DataSource = null;
            Grid.DataBind();
            Analisis analisis = new Analisis();


        }

        public Analisis LlenaClase()
        {
            Analisis analisis = new Analisis();
            analisis = (Analisis)ViewState["Analisis"];
            analisis.PacienteId = Convert.ToInt32(PacienteDropDownList.SelectedValue);
            analisis.AnalisisId = Convert.ToInt32( AnalisisIdNumericUpDown.Text);
            analisis.Balance = Convert.ToDecimal(BalanceTextBox.Text);
            analisis.FechaAnalisis = DateTime.Now;
            analisis.Monto = Convert.ToDecimal(MontoTextBox.Text);
            

            return analisis;
        }

        private void LlenaCampo(Analisis analisis)
        {
           ((Analisis) ViewState["Analisis"]).Detalle = analisis.Detalle;
            PacienteDropDownList.Text = analisis.PacienteId.ToString();
            BalanceTextBox.Text = analisis.Balance.ToString();
            MontoTextBox.Text = analisis.Monto.ToString();
            FechaTextBox.Text = analisis.FechaAnalisis.ToString();
            AnalisisIdNumericUpDown.Text = analisis.AnalisisId.ToString();
            PacienteDropDownList.Text = analisis.PacienteId.ToString();



            
            this.BindGrid();



        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Analisis> db = new RepositorioBase<Analisis>();
            Analisis analisis = db.Buscar(Convert.ToInt32(AnalisisIdNumericUpDown.Text));
            return (analisis != null);

        }





        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            int id;

            RepositorioBase<Analisis> db = new RepositorioBase<Analisis>();
            Analisis analisis = new Analisis();
            int.TryParse(AnalisisIdNumericUpDown.Text, out id);
            Limpiar();


            analisis = db.Buscar(id);

            if (analisis != null)
            {

                LlenaCampo(analisis);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro ese analisis", "Error", "error");

            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

       
            Analisis anlisis;
            bool paso = false;

            anlisis = LlenaClase();


            if (AnalisisIdNumericUpDown.Text == 0.ToString())
            {
                paso = AnalisisBLL.Guardar(anlisis);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "El campo descripcion no puede estar vacio", "Error", "error");
                    return;
                }
                paso = AnalisisBLL.Modificar(anlisis);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, " Se ha Guardado", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            if (Utilitarios.Utils.ToInt(AnalisisIdNumericUpDown.Text) > 0)
            {
                int id = Convert.ToInt32(AnalisisIdNumericUpDown.Text);

                if (AnalisisBLL.Eliminar(id))
                {

                    Utilitarios.Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utilitarios.Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se pudo eliminar, Anlaisis no existe", "error", "error");
            }

        }

        protected void Grid_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
        

        }

        protected void Grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Analisis analisis = new Analisis();
            analisis = (Analisis)ViewState["Analisis"];
            ViewState["Analisis"] = analisis.Detalle;

            int Fila = e.RowIndex;

            analisis.Detalle.RemoveAt(Fila);
            this.BindGrid();
            ResultadoTextBox.Text = string.Empty;




        }
    }
}