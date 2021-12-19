using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Interfaces
{
   public interface IServicioReportesSemanales
    {
        List<DTO.DTO_ReporteSemanal> GetReportesSemanalaes(DTO.DTO_Usuario usuario);
    }
}
