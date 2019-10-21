using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BLL
{
    public class PagosBLL
    {


        public static bool Guardar(Pagos pago)
        {

            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Pagos.Add(pago) != null)
                {
                    foreach (var item in pago.Detalle)
                    {
                        contexto.Analisis.Find(item.AnalisisId).Balance -= (decimal)item.MontoPagado;
                       

                    }

                    contexto.Pacientes.Find(pago.PacienteId).Balance -= (decimal)pago.MontoPagado;

                    contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }
                //siempre hay que cerrar la conexion
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Modificar(Pagos pago)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Pagos PagoAnt = PagosBLL.Buscar(pago.PagoId);


                decimal modificado = pago.MontoPagado - PagoAnt.MontoPagado;

                var Analisis = contexto.Analisis.Find(pago.AnalisisId);
                Analisis.Balance += modificado;
                AnalisisBLL.Modificar(Analisis);

                contexto.Entry(pago).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Pagos pago = contexto.Pagos.Find(id);

                contexto.Analisis.Find(pago.AnalisisId).Balance += pago.MontoPagado;

                contexto.Pagos.Remove(pago);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public static Pagos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Pagos pago = new Pagos();

            try
            {
                pago = contexto.Pagos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
        }


        public static List<Pagos> GetList(Expression<Func<Pagos, bool>> expression)
        {
            List<Pagos> pagos = new List<Pagos>();
            Contexto contexto = new Contexto();

            try
            {
                pagos = contexto.Pagos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return pagos;
        }
    }
}
