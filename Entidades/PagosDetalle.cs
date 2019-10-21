using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PagosDetalle
    {
        [Key]
        public int Id { get; set; }

        public int PagoId { get; set; }
        public int AnalisisId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoAnalisis{ get; set; }
        public decimal BalancePendiente { get; set; }
        public decimal MontoPagado { get; set; }

        public PagosDetalle()
        {
            Id = 0;
            PagoId = 0;
            Fecha = DateTime.Now;
            AnalisisId = 0;
            MontoAnalisis = 0;
            BalancePendiente = 0;
            MontoPagado = 0;
        }

        public PagosDetalle(int id, int pagoId, int analisisId, DateTime fecha, decimal montoAnalisis, decimal balancePendiente, decimal montoPagado)
        {
            Id = id;
            PagoId = pagoId;
            AnalisisId = analisisId;
            Fecha = fecha;
            MontoAnalisis = montoAnalisis;
            BalancePendiente = balancePendiente;
            MontoPagado = montoPagado;
        }
    }
}
