using API_Comun;
using API_Dominio.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Interfaces
{
   public interface IRepositorioCuentas : IRepositorio<Cuenta>
    {
        List<Cuenta> GetCuentas(Usuario usuario);
        Cuenta ConsultarPorId(int idCuenta,Usuario usuario);
    }
}
