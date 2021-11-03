using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.DTO
{
   public class DTO_Historial
    {
        public int idHistorial { get; set; }
        public int idCuenta { get; set; }
        public int idUsuario { get; set; }
        public string descripcion_Movimiento { get; set; }
        public DateTime fecha_movimiento { get; set; }
        public double monto_movimiento { get; set; }
    }
}
