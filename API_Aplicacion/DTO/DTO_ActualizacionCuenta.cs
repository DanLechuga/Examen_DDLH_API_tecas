using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.DTO
{
   public class DTO_ActualizacionCuenta
    {
        public int Id_Cuenta { get; set; }
        public double Saldo { get; set; }
        public string Movimiento { get; set; }
        public string NombreUsuario { get; set; }
        public double MontoAMiniobrar { get; set; }
    }
}
