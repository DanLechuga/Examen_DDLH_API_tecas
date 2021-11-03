using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Examen_DDLH_API_tecas.Modelos
{
    
    public class ModeloRetiro
    {
        
        public int Id_Cuenta { get; set; }
        
        public string DescripcionCuenta { get; set; }
        
        public double Saldo { get; set; }
        
        public double CantidadAManiaobrar { get; set; }
        
        public string Movimiento { get; set; }
        
        public string NombreUsuario { get; set; }
    }
}
