using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Pagos
    {
        [Key]

        public int PagoId { get; set; }
        public int PacienteId { get; set; }
        public int AnalisisId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoPagado { get; set; }
 

        public virtual List<PagosDetalle> Detalle { get; set; }



        public Pagos()
        {
            PagoId = 0;
            PacienteId = 0;
            AnalisisId = 0;
            Fecha = DateTime.Now;
            MontoPagado = 0;

            Detalle = new List<PagosDetalle>();
        }
    }
}
