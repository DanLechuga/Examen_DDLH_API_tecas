using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_DDLH_API_tecas.Modelos
{
    public class ModeloCuenta
    {
        public ModeloCuenta(int id_cuenta,string descripcioncuneta,double saldo)
        {
            this.Id_Cuenta = id_cuenta;
            this.DescripcionCuenta = descripcioncuneta;
            this.Saldo = saldo;
        }
        public int Id_Cuenta { get; set; }
        public string DescripcionCuenta { get; set; }
        public double Saldo { get; set; }
    }
}
