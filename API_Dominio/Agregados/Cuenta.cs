using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Dominio.Agregados
{
   public class Cuenta : Agregado
    {
        public string DescripcionCuenta { get; set; }
        public double SaldoCuenta { get; set; }
        public int IdUsuario { get; set; }
        private Cuenta(int idcuenta,string descripcion,double saldo,int idUsuario)
        {
            this.Id = idcuenta;
            this.DescripcionCuenta = descripcion;
            this.SaldoCuenta = saldo;
            this.IdUsuario = idUsuario;

        }
        public static Cuenta Crear(int idcuenta,string descripcion, double saldo, int idUsuario)
        {
            return new Cuenta(idcuenta,descripcion,saldo,idUsuario);
        }
    }
}
