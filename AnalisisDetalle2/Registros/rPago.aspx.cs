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
    public partial class rPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          

            if (!Page.IsPostBack)
            {
                CargarPaciente();
                CargarAnalisis();


                ViewState["Pagos"] = new Pagos();
                // ViewState["Detalle"] = new Pagos().Detalle;
                BindGrid();

                PagoIdNumericUpDown.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString();

                int ID = Utilitarios.Utils.ToInt(Request.QueryString["id"]);

                if (ID > 0)
                {
                    BLL.RepositorioBase<Pagos> db = new RepositorioBase<Pagos>();
                    var us = db.Buscar(ID);

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


        private void CargarPaciente()
        {
            if (!Page.IsPostBack)
            {
                RepositorioBase<Pacientes> db = new RepositorioBase<Pacientes>();
               

                PacienteIdTextBox.DataSource = db.GetList(t => true);
                PacienteIdTextBox.DataValueField = "PacienteId";
                PacienteIdTextBox.DataTextField = "Nombre";
                PacienteIdTextBox.DataBind();

                ViewState["Pagos"] = new Pagos();
            }

        }

        private void CargarAnalisis()
        {
           
                RepositorioBase<Analisis> db = new RepositorioBase<Analisis>();

                int Paciente = Convert.ToInt32(PacienteIdTextBox.SelectedValue);

                AnalisisIdTextbox.DataSource = db.GetList(t => t.PacienteId == Paciente);
                AnalisisIdTextbox.DataValueField = "AnalisisId";
                AnalisisIdTextbox.DataTextField = "AnalisisId";
                AnalisisIdTextbox.DataBind();

                ViewState["Pagos"] = new Pagos();
            

        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Pagos pago = new Pagos();
            RepositorioBase<Analisis> db = new RepositorioBase<Analisis>();

            pago = (Pagos)ViewState["Pagos"];
            var detalle = db.Buscar(Convert.ToInt32(AnalisisIdTextbox.SelectedValue));
            //pago.Detalle.Add(new Entidades.PagosDetalle(0,0, Convert.ToDateTime(FechaTextBox.Text),Convert.ToDecimal( MontoAnalisisTextBox.Text),0,Convert.ToDecimal( MontoAPagarTextBox.Text)));
            pago.Detalle.Add(new Entidades.PagosDetalle(0,Convert.ToInt32( PagoIdNumericUpDown.Text), Convert.ToInt32( AnalisisIdTextbox.SelectedValue),detalle.FechaAnalisis, detalle.Monto, detalle.Balance-Convert.ToDecimal(MontoAPagarTextBox.Text), Convert.ToInt32(MontoAPagarTextBox.Text)));
            ViewState["Pagos"] = pago.Detalle;
            this.BindGrid();
           
            Grid.Columns[1].Visible = false;

            decimal Calculador = 0;
            foreach (var item in pago.Detalle)
            {
                Calculador = Calculador + item.MontoPagado;
            }
            MontoTotalTextBox.Text = Calculador.ToString();
            MontoAPagarTextBox.Text = Calculador.ToString();
      
        }
    

        protected void BindGrid()
        {
            
                Grid.DataSource = ((Pagos)ViewState["Pagos"]).Detalle;
                Grid.DataBind();
            
        }


        public Pagos LlenaClase()
        {
            Pagos pago = new Pagos();
            pago = (Pagos)ViewState["Pagos"];
            pago.PagoId = Convert.ToInt32(PagoIdNumericUpDown.Text);
            pago.PacienteId = Convert.ToInt32(PacienteIdTextBox.SelectedValue);
            pago.AnalisisId = Convert.ToInt32(AnalisisIdTextbox.SelectedValue);
            pago.MontoPagado = Convert.ToDecimal(MontoTotalTextBox.Text);
            pago.Fecha = DateTime.Now;

            return pago;
        }

        public void LlenaCampo(Pagos pago)
        {
            Limpiar();
            PagoIdNumericUpDown.Text = pago.PagoId.ToString();
            FechaTextBox.Text = pago.Fecha.ToString("yyyy-MM-dd");
            MontoTotalTextBox.Text = pago.MontoPagado.ToString();
            PacienteIdTextBox.Text = pago.PacienteId.ToString();
            AnalisisIdTextbox.Text = pago.AnalisisId.ToString();
          
            this.DataBind();

          
        }
        protected void Limpiar()
        {
            PagoIdNumericUpDown.Text = "0";
            PagoIdNumericUpDown.Enabled = true;
            MontoTotalTextBox.Text = "0";
            MontoAnalisisTextBox.Text = "0";
            MontoAPagarTextBox.Text = "0";

            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            Grid.DataSource = null;
            Grid.DataBind();
            

        }


        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Pagos> db = new RepositorioBase<Pagos>();
            Pagos pago = db.Buscar(Convert.ToInt32(PagoIdNumericUpDown.Text));
            return (pago != null);

        }



        protected void BuscarButton_Click(object sender, EventArgs e)
        {

            int id;

            RepositorioBase<Pagos> db = new RepositorioBase<Pagos>();
            Pagos pago = new Pagos();
            int.TryParse(PagoIdNumericUpDown.Text, out id);
            Limpiar();


            pago = db.Buscar(id);

            if (pago != null)
            {

                LlenaCampo(pago);

            }
            else
            {
                Utilitarios.Utils.ShowToastr(this.Page, "No se encontro ese Pago", "Error", "error");

            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            Pagos pago;
            bool paso = false;

            pago = LlenaClase();


            if (PagoIdNumericUpDown.Text == 0.ToString())
            {
                paso = PagosBLL.Guardar(pago);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    Utilitarios.Utils.ShowToastr(this.Page, "Este Pago no existe en la base de datos", "Error", "error");
                    return;
                }
                paso = PagosBLL.Modificar(pago);
            }

            if (paso)
                Utilitarios.Utils.ShowToastr(this.Page, " Se ha Guardado", "Exito", "success");
            else
                Utilitarios.Utils.ShowToastr(this.Page, "Se profujo un error al guardar", "Error", "error");
            Limpiar();
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {

            if (Utilitarios.Utils.ToInt(PagoIdNumericUpDown.Text) > 0)
            {
                int id = Convert.ToInt32(PagoIdNumericUpDown.Text);

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

        protected void PacienteIdTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAnalisis();
        }

        protected void AnalisisIdTextbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Analisis> db = new RepositorioBase<Analisis>();
            Analisis analisis = new Analisis();
            int.TryParse(AnalisisIdTextbox.SelectedValue, out id);


            analisis = db.Buscar(id);

            MontoAnalisisTextBox.Text = Convert.ToString(analisis.Monto);

        }

        protected void AnalisisIdTextbox_TextChanged(object sender, EventArgs e)
        {
            int id;
            RepositorioBase<Analisis> db = new RepositorioBase<Analisis>();
            Analisis analisis = new Analisis();
            int.TryParse(AnalisisIdTextbox.SelectedValue, out id);


            analisis = db.Buscar(id);

            MontoAnalisisTextBox.Text = Convert.ToString(analisis.Monto);
        }
    }
}