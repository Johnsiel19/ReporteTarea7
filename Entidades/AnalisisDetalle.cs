using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class AnalisisDetalle
    {


        [Key]

        public int id { get; set; }

        public int AnalisisId { get; set; }

        public int TipoAnalisisId { get; set; }

        public string Resultado { get; set; }

        public decimal Precio { get; set; }





        public AnalisisDetalle()
        {
            id = 0;
            AnalisisId = 0;
            TipoAnalisisId = 0;
            Resultado = String.Empty;
            Precio = 0;

        }

        public AnalisisDetalle(int analisisDetalleId, int analisisId, int tipoAnalisisId, string resultado, decimal precio)
        {
            id = analisisDetalleId;
            AnalisisId = analisisId;
            TipoAnalisisId = tipoAnalisisId;
            Resultado = resultado;
            Precio = precio;
        }
    }
}
