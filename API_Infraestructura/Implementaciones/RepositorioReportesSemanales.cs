using API_Dominio.Agregados;
using API_Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Comun;
using Dapper;

namespace API_Infraestructura.Implementaciones
{

    class DTO_ReporteSemanal
    {
        public int id_ReporteSemanal { get; set; }
        public int id_Usuario { get; set; }
        public string diaSemana { get; set; }
        public DateTime fechaActividad { get; set; }
        public string concepto { get; set; }
        public string actividad { get; set; }
        public TimeSpan horaInicio { get; set; }
        public TimeSpan horaFin { get; set; }
        public int totalhoras { get; set; }
    }
    public class RepositorioReportesSemanales : IRepositorioReportesSemanales
    {
        public IUnidadDetrabajo UnidadDetrabajo { get; set; }
        public RepositorioReportesSemanales(IUnidadDetrabajo unidadDetrabajo)
        {
            this.UnidadDetrabajo = unidadDetrabajo;
        }
        public List<ReporteSemanal> GetListReporte(Usuario usuario)
        {
            List<ReporteSemanal> ListaReportes = new();
             
            try
            {
                DynamicParameters parameters = new();
                parameters.Add("@idUsuario",usuario.Id);
                CommandDefinition command = new ("SP_ConsultaReporteSemanal",parameters,commandTimeout:0, commandType:System.Data.CommandType.StoredProcedure);
                List<DTO_ReporteSemanal> ListaDTOS = (List<DTO_ReporteSemanal>)UnidadDetrabajo.SqlConnection.Query<DTO_ReporteSemanal>(command);
                foreach (var item in ListaDTOS)
                {
                    ListaReportes.Add(ReporteSemanal.Crear(item.id_ReporteSemanal,item.id_Usuario,item.diaSemana,item.fechaActividad,item.concepto,item.actividad,item.horaInicio,item.horaFin,item.totalhoras));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ListaReportes;
        }

        public void Guardar(ReporteSemanal agregado)
        {
            throw new NotImplementedException();
        }
    }
}
