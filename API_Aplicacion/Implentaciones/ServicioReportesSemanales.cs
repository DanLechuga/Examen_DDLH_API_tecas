using API_Aplicacion.DTO;
using API_Aplicacion.Interfaces;
using API_Dominio.Agregados;
using API_Infraestructura;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Aplicacion.Implentaciones
{
    public class ServicioReportesSemanales : IServicioReportesSemanales
    {
        public IRepositorioReportesSemanales RepositorioReportesSemanales { get; set; }
        public IRepositorioUsuarios RepositorioUsuarios { get; set; }
        public ServicioReportesSemanales(IRepositorioReportesSemanales repositorioReportesSemanales, IRepositorioUsuarios repositorioUsuarios)
        {
            this.RepositorioReportesSemanales = repositorioReportesSemanales;
            this.RepositorioUsuarios = repositorioUsuarios;
        }
        public List<DTO_ReporteSemanal> GetReportesSemanalaes(DTO_Usuario usuario)
        {
            List<DTO_ReporteSemanal> listDTO = new();
            Usuario usuarioAconsultar = RepositorioUsuarios.GetUsuarioPorNombre(usuario.Username);
            List<ReporteSemanal> ListaReportes = RepositorioReportesSemanales.GetListReporte(usuarioAconsultar);
            foreach (var item in ListaReportes)
            {
                listDTO.Add(new DTO_ReporteSemanal() {IdReporte = item.Id,IdUsuario = item.IdUsuario,DiaDeLaSemana = item.DiaDeLaSemana, Actividad = item.Actividad,FechaIngresoActividad = item.FechaDeLaActividad, Concepto = item.Concepto, HoraFin = item.HoraFin, HoraInicio = item.HoraInicio, TotalDeHoras = item.HorasTotales });
            }

            return listDTO;
        }
    }
}
