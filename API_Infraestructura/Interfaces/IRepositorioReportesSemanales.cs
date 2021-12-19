using API_Comun;
using API_Dominio.Agregados;
using System.Collections.Generic;

namespace API_Infraestructura.Interfaces
{
    public interface IRepositorioReportesSemanales: IRepositorio<ReporteSemanal>
    {
        public List<ReporteSemanal> GetListReporte(Usuario usuario);
    }
}