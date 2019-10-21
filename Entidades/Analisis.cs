using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    [Serializable]
    public class Analisis
    {
        [Key]
        public int AnalisisId { get; set; }
        public DateTime FechaAnalisis { get; set; }
        public int PacienteId { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }


        public virtual List<AnalisisDetalle> Detalle { get; set; }
        public Analisis()
        {
            AnalisisId = 0;
            PacienteId = 0;
            FechaAnalisis = DateTime.Now;
            Monto = 0;
            Balance = 0;
            Detalle = new List<AnalisisDetalle>();
        }

  
    }
}
