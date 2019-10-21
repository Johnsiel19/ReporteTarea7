using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class TipoAnalisis
    {

        [Key]
        public int TipoAnalisisId { get; set; }

        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }


        public TipoAnalisis()
        {
            TipoAnalisisId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Precio = 0;
        }
    }
}

