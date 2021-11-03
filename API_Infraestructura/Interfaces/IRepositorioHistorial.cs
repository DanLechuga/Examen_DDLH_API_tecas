using API_Comun;
using API_Dominio.Agregados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Infraestructura.Interfaces
{
   public interface IRepositorioHistorial: IRepositorio<Historial>
    {
        List<Historial> ConsultaTodosLosHistoriales(Usuario usuario);
    }
}
