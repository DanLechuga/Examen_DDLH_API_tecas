using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.DTO
{
   public class DTO_Cuenta
    {
        public DTO_Cuenta(int id,string descripcion,double saldo)
        {
            this.DescripcionCuenta = descripcion;
            this.id_cuenta = id;
            this.saldo = saldo;
        }
        public string DescripcionCuenta { get; set; }
        public int id_cuenta { get; set; }
        public double saldo { get; set; }
    }
}
