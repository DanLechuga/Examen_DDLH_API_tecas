using API_Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Dominio.Agregados
{
    public class Historial : Agregado
    {
        public int Cuenta_id { get; set; }
        public int Usuario_id { get; set; }
        public DateTime Fecha_transaccion { get; set; }
        public double Monto_trasaccion { get; set; }
        public string Descripcion_movimiento { get; set; }
        private Historial(int idHistorial,int idCuenta,int idUsuario,DateTime fecha_movimiento,double monto_movimiento,string descripcion_movimiento)
        {
            this.Id = idHistorial;
            this.Cuenta_id = idCuenta;
            this.Usuario_id = idUsuario;
            this.Fecha_transaccion = fecha_movimiento;
            this.Monto_trasaccion = monto_movimiento;
            this.Descripcion_movimiento = descripcion_movimiento;
        }
        public static Historial Crear(int idHistorial, int idCuenta, int idUsuario, DateTime fecha_movimiento, double monto_movimiento, string descripcion_movimiento)
        {
            return new Historial( idHistorial,  idCuenta, idUsuario,  fecha_movimiento, monto_movimiento,descripcion_movimiento);
        }
    }
}
