using API_Aplicacion.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Interfaces
{
   public interface IMovimientosCuentas
    {
        List<DTO_Cuenta> ConsultaTodasLasCuentas(DTO_Usuario usuario);
        DTO_Cuenta ConsultarCuentaPorId(int idCuenta,string nombreU);
        void PutCuenta(DTO_ActualizacionCuenta actualizacionCuenta);
    }
}
