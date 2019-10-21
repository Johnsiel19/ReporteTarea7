using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;
using System.Data.Entity;

namespace BLL
{
    public class AnalisisBLL
    {
        public static bool Guardar(Analisis analisis)
        {
            bool paso = false;
            Contexto contexto = new Contexto();


            try
            {
                if (contexto.Analisis.Add(analisis) != null)

                    foreach (var item in analisis.Detalle)
                    {
                        contexto.TipoAnaliss.Find(item.TipoAnalisisId).Cantidad += 1;
                        contexto.Pacientes.Find(analisis.PacienteId).Balance += item.Precio;

                    }



                contexto.SaveChanges();
                paso = true;

                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool Modificar(Analisis analisis)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var analis = AnalisisBLL.Buscar(analisis.AnalisisId);


                if (analisis != null)
                {
                    foreach (var item in analis.Detalle)
                    {
                        contexto.TipoAnaliss.Find(item.TipoAnalisisId).Cantidad -= 1;
                        contexto.Pacientes.Find(analis.PacienteId).Balance -= item.Precio;

                        if (!analisis.Detalle.ToList().Exists(v => v.id == item.id))
                        {
                           
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in analisis.Detalle)
                    {
                        contexto.TipoAnaliss.Find(item.TipoAnalisisId).Cantidad += 1;
                        contexto.Pacientes.Find(item.TipoAnalisisId).Balance -= item.Precio;
                        var estado = item.TipoAnalisisId > 0 ? EntityState.Modified : EntityState.Added;
                        contexto.Entry(item).State = estado;
                    }

                    decimal modificado = analisis.Balance - analis.Balance;


                    analisis.Balance += modificado;


                    contexto.Entry(analisis).State = EntityState.Modified;
                }



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
            Contexto db = new Contexto();
            try
            {

                Analisis factura = db.Analisis.Find(id);

                foreach (var item in factura.Detalle)
                {
                    db.TipoAnaliss.Find(item.TipoAnalisisId).TipoAnalisisId += 1;
                    
                }

                db.Pacientes.Find(factura.PacienteId).Balance -= factura.Balance;

                db.Analisis.Remove(factura);


                var eliminar = db.Analisis.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Analisis Buscar(int id)
        {
            Analisis analisis = new Analisis();
            Contexto db = new Contexto();


            try
            {
                analisis = db.Analisis.Find(id);
                if (analisis != null)
                {
                    analisis.Detalle.Count();
                }


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return analisis;

        }

    


    }
}
